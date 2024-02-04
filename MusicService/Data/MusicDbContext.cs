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
        public DbSet<ArtistSong> ArtistsSongs { get; set; }
        public DbSet<FavoriteAlbum> FavoriteAlbums { get; set; }
        public DbSet<FavoriteArtist> FavoriteArtists { get; set; }
        public DbSet<UserArtist> UsersArtists { get; set; }
        public MusicDbContext(DbContextOptions<MusicDbContext>? options) : base(options) { }
    }
}
