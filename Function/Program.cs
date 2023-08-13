using Application;
using Microsoft.Extensions.Hosting;
using Repository;

var host = new HostBuilder()
	.ConfigureServices(x =>
	{
		x.AddSqlDbContext();
		x.AddApplication();
	})
	.ConfigureFunctionsWorkerDefaults()
	.Build();

host.Run();
