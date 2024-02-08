using ApproveRequestToJoinGroup.WorkerServie;
using NotificationMicroservice.SharedLibrary;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddShared();
    })
    .Build();

host.Run();
