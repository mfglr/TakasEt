using Application;
using Microsoft.Extensions.Hosting;
using Repository;
using Service;

var host = new HostBuilder()
	.ConfigureServices(x =>
	{
		x.AddSqlDbContext();
		x.AddApplication();
		x.AddServices();
	})
	.ConfigureFunctionsWorkerDefaults()
	.Build();

host.Run();
