using SendEmailConfirmationMail.WorkerService;
using SharedLibrary;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddAppEventsSubscriber();
        services.AddSmtpEmailService();
    })
    .Build();

host.Run();
