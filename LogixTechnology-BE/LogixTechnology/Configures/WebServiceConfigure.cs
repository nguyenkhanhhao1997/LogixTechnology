using LogixTechnology.Constant;
using LogixTechnology.Data.Models;
using LogixTechnology.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LogixTechnology.Configures
{
    public class WebServiceConfigure
    {
        public WebServiceConfigure(IConfiguration configuration, IServiceCollection services) 
        {
            services.AddControllers();

            if (!string.IsNullOrEmpty(configuration.GetConnectionString(LogixTechnologyConstant.KeyConnString)))
            {
                services.AddDbContext<EFDataContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString(LogixTechnologyConstant.KeyConnString));
                });
            }

            var cors = configuration.GetValue<string>(LogixTechnologyConstant.KeyApiCorsPolicy);
            services.AddCors(options => options.AddPolicy(LogixTechnologyConstant.KeyApiCorsPolicy, builder =>
            {
                if (!string.IsNullOrEmpty(cors))
                {
                    builder.WithOrigins(cors.Split(",")).AllowAnyMethod().AllowAnyHeader();
                }
            }));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserActivityRepositores, UserActivityRepositores>();
        }
    }
}
