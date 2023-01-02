using Application.Interfaces;
using Infrastructure.Maps;
using Infrastructure.Persistence;
using Infrastructure.services;

namespace WebApi.Startups;

internal static class ServiceRegistration
{
	internal static WebApplicationBuilder RegisterServices(this WebApplicationBuilder applicationBuilder)
	{
		applicationBuilder.Services.RegisterServices();
		return applicationBuilder;
	}

	private static void RegisterServices(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddControllers();
		serviceCollection.AddEndpointsApiExplorer();
		serviceCollection.AddSwaggerGen();
		serviceCollection.AddCors(options => { options.AddPolicy(name: "all", policy  => { policy.WithOrigins("*").WithMethods("*").WithHeaders("*"); }); });
		
		serviceCollection.AddDbContext<InvoiceDbContext>();
		
		serviceCollection.AddScoped<ICustomerService, CustomerService>();
		serviceCollection.AddScoped<IInvoiceService, InvoiceService>();
		
		serviceCollection.AddAutoMapper(expression =>
		{
			expression.AddProfile<CustomerMap>();
			expression.AddProfile<InvoiceMap>();
			expression.AddProfile<ProductMap>();
		});


	}
}
