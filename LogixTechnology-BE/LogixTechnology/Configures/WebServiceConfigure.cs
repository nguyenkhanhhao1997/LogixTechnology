using LogixTechnology.Constant;
using LogixTechnology.Data.Models;
using LogixTechnology.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LogixTechnology.Configures
{
    public class WebServiceConfigure
    {
        public WebServiceConfigure(IConfiguration configuration, IServiceCollection services) 
        {
            services.AddControllers();

            //Database configure
            if (!string.IsNullOrEmpty(configuration.GetConnectionString(LogixTechnologyConstant.KeyConnString)))
            {
                services.AddDbContext<EFDataContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString(LogixTechnologyConstant.KeyConnString));
                });
            }
            
            //Cors configure
            var cors = configuration.GetValue<string>(LogixTechnologyConstant.KeyApiCorsPolicy);
            services.AddCors(options => options.AddPolicy(LogixTechnologyConstant.KeyApiCorsPolicy, builder =>
            {
                if (!string.IsNullOrEmpty(cors))
                {
                    builder.WithOrigins(cors.Split(",")).AllowAnyMethod().AllowAnyHeader();
                }
            }));

            //DI configure
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserActivityRepositores, UserActivityRepositores>();

            //JWT configure
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration[LogixTechnologyConstant.JwtIssuer],
                    ValidAudience = configuration[LogixTechnologyConstant.JwtAudience],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[LogixTechnologyConstant.JwtKey])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            services.AddAuthorization();
        }
    }
}
