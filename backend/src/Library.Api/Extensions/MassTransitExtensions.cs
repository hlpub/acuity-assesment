using Library.Api.SettingsHelpers;
using Library.App.Consumers;
using MassTransit;

namespace Library.Api.Extensions;

public static class MassTransitExtensions
{
    public static void AddConsumers(this IBusRegistrationConfigurator config)
    {
        config.AddConsumer<MoreProcessingConsumer>();
    }

    public static void ConfigureEndpoints(this IRabbitMqBusFactoryConfigurator config,
        IBusRegistrationContext context, BusSettings busSettings)
    {
        config.ReceiveEndpoint(busSettings.MoreProcessingQueueName, re =>
        {
            re.ConfigureConsumer<MoreProcessingConsumer>(context);
        });

        config.ConfigureEndpoints(context);
    }
}
