using Microsoft.EntityFrameworkCore;
using MusicService.Data;
using MusicService.Data.Repositories;
using MusicService.Interfaces;
using MusicService.Services;

namespace MusicService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            app.UseAuthorization();

            app.MapControllers();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<MusicDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("SqlServerConnectionString")
                ?? throw new InvalidOperationException("Connection string 'SqlServerConnectionString' not found.")));
            //services.AddDbContext<MusicDbContext>(options =>
            //    options.UseSqlite(config.GetConnectionString("MainConnectionString") 
            //    ?? throw new InvalidOperationException("Connection string 'MainConnectionString' not found.")));


            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<ISongRepository, SongRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<SongService>();
            services.AddScoped<ArtistService>();
            services.AddScoped<AlbumService>();
            services.AddScoped<UserService>();

            services.AddAutoMapper(typeof(MapperProfile).Assembly);

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}