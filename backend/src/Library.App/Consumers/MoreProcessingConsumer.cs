using System.Diagnostics;
using System.Globalization;
using Library.Common.Messages;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Library.App.Consumers;
public class MoreProcessingConsumer : IConsumer<IBookSearchPerformedMessage>
{
    private readonly ILogger<MoreProcessingConsumer> _logger;


    public MoreProcessingConsumer(ILogger<MoreProcessingConsumer> logger)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));

        _logger = logger;
    }

    public async Task Consume(ConsumeContext<IBookSearchPerformedMessage> context)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));

            var messageId = context.Message.MessageId.ToString();
            var executionWatch = new Stopwatch();

            executionWatch.Start();
            _logger.LogInformation("Starting {Consumer} Message Id: {MessageId} received",
                nameof(MoreProcessingConsumer), messageId);

            //Do something

            executionWatch.Stop();
            _logger.LogInformation("Finishing {Consumer} Message Id: {MessageId} processed. Execution time {Timer}",
               nameof(MoreProcessingConsumer), messageId,
               executionWatch.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing {Consumer} for Message Id {MessageId}", nameof(MoreProcessingConsumer),
                context?.Message.MessageId.ToString());

            throw;
        }
    }
}
