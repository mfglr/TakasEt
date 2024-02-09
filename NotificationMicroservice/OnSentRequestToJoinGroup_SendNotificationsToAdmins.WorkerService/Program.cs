using NotificationMicroservice.SharedLibrary;
using OnSentRequestToJoinGroup_SendNotificationsToAdmins.WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddNotificationSharedLibrary();
    })
    .Build();

host.Run();
