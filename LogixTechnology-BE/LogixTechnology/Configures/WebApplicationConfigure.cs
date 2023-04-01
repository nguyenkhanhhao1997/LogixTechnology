using LogixTechnology.Constant;

namespace LogixTechnology.Configures
{
    public class WebApplicationConfigure
    {
        public WebApplicationConfigure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            app.UseCors(LogixTechnologyConstant.KeyApiCorsPolicy);

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
