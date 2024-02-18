using Microsoft.EntityFrameworkCore;
using MusicService.Models;

namespace MusicService.Data
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public MusicDbContext(DbContextOptions<MusicDbContext>? options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(u => u.Artist)
            .WithOne(a => a.User)
            .HasForeignKey<Artist>(a => a.UserId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.FavoriteArtists)
                .WithMany(a => a.UserFans)
                .UsingEntity(j => j.ToTable("FavoriteArtists"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.FavoriteAlbums)
                .WithMany(a => a.UserFans)
                .UsingEntity(j => j.ToTable("FavoriteAlbums"));
        }
    }
}
