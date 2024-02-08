using NotificationMicroservice.SharedLibrary;
using OnApprovedRequestToJoinGroup_SendNotificationToUser.WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddShared();
    })
    .Build();

host.Run();
