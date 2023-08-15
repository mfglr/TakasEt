using Application;
using Command;
using Microsoft.Extensions.Hosting;
using Repository;
using Service;

var host = new HostBuilder()
	.ConfigureServices(x =>
	{
		x.AddSqlDbContext();
		x.AddApplication();
		x.AddServices();
		x.AddCommand();
	})
	.ConfigureFunctionsWorkerDefaults()
	.Build();

host.Run();
