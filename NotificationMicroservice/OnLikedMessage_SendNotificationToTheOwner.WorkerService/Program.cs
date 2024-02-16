using OnLikedMessage_SendNotificationToTheOwner.WorkerService;
using SharedLibrary;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddIntegrationEventsSubscriber();
    })
    .Build();

host.Run();
