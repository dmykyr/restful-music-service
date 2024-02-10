using MusicService.Models;
using System.Data.Entity;

namespace MusicService.Data.Repositories
{
    public class UserRepository
    {
        private readonly MusicDbContext _context;

        public UserRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Add(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<User> Update(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<User> Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return user;
            }

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Album>> GetFavoriteAlbums(Guid userId, string searchName)
        {
            return await _context.FavoriteAlbums
                .Include(fa => fa.Album)
                .Where(fa => fa.UserId == userId && fa.Album.Title.Contains(searchName))
                .Select(fa => fa.Album)
                .ToListAsync();
        }

        public async Task<IEnumerable<Artist>> GetFavoriteArtists(Guid userId, string searchName)
        {
            return await _context.FavoriteArtists
                .Include(fa => fa.Artist)
                .Where(fa => fa.UserId == userId && fa.Artist.Name.Contains(searchName))
                .Select(fa => fa.Artist)
                .ToListAsync();
        }

        public async Task AddFavoriteAlbum (Guid userId, Guid albumId)
        {
            await _context.FavoriteAlbums.AddAsync(new FavoriteAlbum { UserId = userId, AlbumId = albumId });
            await _context.SaveChangesAsync();
        }

        public async Task AddFavoriteArtist(Guid userId, Guid artistId)
        {
            await _context.FavoriteArtists.AddAsync(new FavoriteArtist { UserId = userId, ArtistId = artistId });
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFavoriteAlbum(Guid userId, Guid albumId)
        {
            var favoriteAlbum = await _context.FavoriteAlbums.FirstAsync(fa => fa.UserId == userId && fa.AlbumId == albumId);
            _context.FavoriteAlbums.Remove(favoriteAlbum);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFavoriteArtist(Guid userId, Guid artistId)
        {
            var favoriteArtist = await _context.FavoriteArtists.FirstAsync(fa => fa.UserId == userId && fa.ArtistId == artistId);
            _context.FavoriteArtists.Remove(favoriteArtist);
            await _context.SaveChangesAsync();
        }
    }
}