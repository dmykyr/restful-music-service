using Microsoft.EntityFrameworkCore;
using MusicService.Data;
using MusicService.Data.Repositories;
using MusicService.Models;

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
            builder.Services.AddScoped<IRepository<Album>, AlbumRepository>();
            builder.Services.AddScoped<IRepository<Song>, SongRepository>();
            builder.Services.AddScoped<IRepository<Artist>, ArtistRepository>();
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<RoleRepository>();
            builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}