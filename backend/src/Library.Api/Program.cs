using Library.Core.DbContexts;
using Library.Core.Extensions;
using Library.Api.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Serilog;
using MassTransit;
using Library.Api.SettingsHelpers;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", false, true)
               .AddJsonFile($"appsettings.{env}.json", true)
               .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();

try
{
    Log.Logger.Information("Starting up...");

    // Add services to the container.
    var services = builder.Services;

    services.AddControllers();
    services.AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddSerilog();

    /*
     * Probably not a good idea in a real world app.
       I did it just to note that is important to define a policy if the API will 
       be exposed to the Internet and consumed from a browser */
    services.AddCors(x => x.AddDefaultPolicy(z => z.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));

    services.AddDbContext<LibraryDbContext>(options =>
        options.UseSqlServer(config.GetSection("ConnectionStrings:LibraryDb").Value));

    var busSettings = config.GetSection("BusSettings").Get<BusSettings>();
    if (busSettings is not null && !busSettings.Host.IsNullOrEmpty()
        && !busSettings.Username.IsNullOrEmpty() && !busSettings.Password.IsNullOrEmpty())
        builder.Services.AddMassTransit(x =>
        {
            x.AddConsumers();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri(busSettings.Host), h =>
                {
                    h.Username(busSettings.Username);
                    h.Password(busSettings.Password);
                });

                cfg.ConfigureEndpoints(context, busSettings);
            });
        });
    services.AddCoreServices();

    var app = builder.Build();

    using (var serviceScope = app?.Services?.GetService<IServiceScopeFactory>()?.CreateScope())
    {
        var context = serviceScope!.ServiceProvider.GetRequiredService<LibraryDbContext>();
        var dbCreator = context.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

        //Probably not the best way to run migrations. Just did it this way for easiness
        if (!dbCreator!.Exists())
        {
            dbCreator.Create();
            context.Database.ExecuteSqlRaw(File.ReadAllText("db.sql"));
        }

    }

    // Configure the HTTP request pipeline.
    app!.UseCors();

    if (app!.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapControllers();

    await app.RunAsync();
}

catch (Exception ex)
{
    Log.Logger.Fatal(ex, "Application start-up failed");
    throw;
}

finally
{
    Log.CloseAndFlush();
}
