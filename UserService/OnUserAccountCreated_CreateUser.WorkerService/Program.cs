using OnUserAccountCreated_CreateUser.WorkerService.Consumers;
using OnUserAccountCreated_CreateUser.WorkerService.Extentions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddServices();
        services.AddAppDbContext();
        services.AddHostedService<UserAccountCreatedEventConsumer>();
    })
    .Build();

host.Run();
