
using LogixTechnology.Configures;

namespace LogixTechnology
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            new WebServiceConfigure(builder.Configuration, builder.Services);
            new WebApplicationConfigure(builder.Build());
        }
    }
}


