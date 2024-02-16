using OnUserAccount_Created_SendEmailConfirmationMail.WorkerService;
using SharedLibrary;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddIntegrationEventsSubscriber();
        services.AddSmtpEmailService();
    })
    .Build();

host.Run();
