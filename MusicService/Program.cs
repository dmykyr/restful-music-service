using Microsoft.EntityFrameworkCore;
using MusicService.Data;

namespace MusicService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MusicDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("MainConnectionString") 
                ?? throw new InvalidOperationException("Connection string 'MainConnectionString' not found.")));

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            builder.Services.AddSingleton<IConfigurationRoot>(option => {
                return configuration;
            });

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}