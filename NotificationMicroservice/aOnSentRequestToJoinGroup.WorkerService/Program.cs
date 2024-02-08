using RequestToJoinGroup.WorkerService;
using NotificationMicroservice.SharedLibrary;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddShared();
        services.AddHostedService<Worker>();
        
    })
    .Build();

host.Run();
