namespace WebApi.Startups;

internal static class MiddleWareRegistration
{

	internal static WebApplication RegisterDefualtMiddleWares(this WebApplication app)
	{
		app.UseSwagger();
		app.UseSwaggerUI();
		
		app.UseCors("all");
		app.UseHttpsRedirection();
		app.UseAuthorization();
		app.MapControllers();

		return app;
	}
}
