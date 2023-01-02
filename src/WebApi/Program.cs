using Serilog;
using WebApi.Startups;

InitializeLogger();

try
{
	Log.Information("Building web application with args {Args}", args);
	var webapp = BuildWebApplication(args);

	Log.Information("Starting web application");
	webapp.Run();
}
catch(Exception ex)
{
	Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
	Log.CloseAndFlush();
}

WebApplication BuildWebApplication(string[] args)
{
	return WebApplication
		.CreateBuilder(args)
		.RegisterServices()
		.Build()
		.RegisterDefualtMiddleWares();
}

static void InitializeLogger()
{
	Log.Logger = new LoggerConfiguration()
		.WriteTo
		.Console()
		.CreateLogger();

}