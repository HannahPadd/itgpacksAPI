using itgpacksAPI;
using Microsoft.EntityFrameworkCore;

namespace itgpacksAPI
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);
            var app = builder.Build();
            using (var serviceScope = app.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ItgPacksContext>();
                context.Database.EnsureCreated();
            }
                startup.Configure(app, builder.Environment);
        }
    }
}