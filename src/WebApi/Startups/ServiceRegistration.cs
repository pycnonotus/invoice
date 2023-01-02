namespace WebApi.StartUps;

internal static class ServiceRegistration
{
	internal static void RegisterServices(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddControllers();
		serviceCollection.AddEndpointsApiExplorer();
		serviceCollection.AddSwaggerGen();
	}
}
