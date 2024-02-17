using Microsoft.EntityFrameworkCore;
using OnUserAccountCreatedByEmail_CreateUser.WorkerService;
using SharedLibrary;
using UserService.Infrastructure;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddIntegrationEventsSubscriber();

        services.AddDbContext<AppDbContext>(
               (sp, opt) =>
               {
                   var configuration = sp.GetRequiredService<IConfiguration>();
                   opt.UseSqlServer(configuration.GetConnectionString("SqlServer"));
               },
               ServiceLifetime.Singleton
           );

    })
    .Build();

host.Run();
