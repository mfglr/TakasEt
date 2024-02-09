using NotificationMicroservice.SharedLibrary;
using OnLikedMessage_SendNotificationToTheOwner.WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddNotificationSharedLibrary();
    })
    .Build();

host.Run();
