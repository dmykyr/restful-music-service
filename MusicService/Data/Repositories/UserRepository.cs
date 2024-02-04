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

        public async Task<List<Album>> GetFavoriteAlbums (Guid id)
        {
            return await _context.UsersAlbums
                .Where(ua => ua.UserId == id)
                .Select(ua => ua.Album)
                .ToListAsync();
            
        }

        public async Task<List<Artist>> GetFavoriteArtists(Guid id)
        {
            return await _context.UsersArtists
                .Where(ua => ua.UserId == id)
                .Select(ua => ua.Artist)
                .ToListAsync();
        }

        public async Task<Album> RemoveFavoriteAlbum(Guid userId, Guid albumId)
        {
            var userAlbum = await _context.UsersAlbums
                .Include(ua => ua.Album)
                .FirstAsync(ua => ua.AlbumId == albumId && ua.UserId == userId);
            _context.UsersAlbums.Remove(userAlbum);
            return userAlbum.Album;
        }
        
        public async Task<Artist> RemoveFavoriteArtist(Guid userId, Guid artistId)
        {
            var userArtist = await _context.UsersArtists
               .Include(ua => ua.Artist)
               .FirstAsync(ua => ua.ArtistId == artistId && ua.UserId == userId);
            _context.UsersArtists.Remove(userArtist);
            return userArtist.Artist;
        }
    }
}