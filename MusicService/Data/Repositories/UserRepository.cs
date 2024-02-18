using MusicService.Models;
using Microsoft.EntityFrameworkCore;

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
            var user = await _context.Users
                .Include(user => user.FavoriteAlbums)
                .FirstOrDefaultAsync(user => user.Id == userId) ?? throw new Exception();

            return user.FavoriteAlbums;
        }

        public async Task<IEnumerable<Artist>> GetFavoriteArtists(Guid userId, string searchName)
        {
            var user = await _context.Users
                .Include(user => user.FavoriteArtists)
                .FirstOrDefaultAsync(user => user.Id == userId) ?? throw new Exception();

            return user.FavoriteArtists;
        }

        public async Task AddFavoriteAlbum (Guid userId, Guid albumId)
        {
            var album = await _context.Albums.FindAsync(albumId) ?? throw new Exception();
            var user = await _context.Users
                .Include(user => user.FavoriteAlbums)
                .FirstOrDefaultAsync(user => user.Id == userId) ?? throw new Exception();

            user.FavoriteAlbums.Add(album);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task AddFavoriteArtist(Guid userId, Guid artistId)
        {
            var artist = await _context.Artists.FindAsync(artistId) ?? throw new Exception();
            var user = await _context.Users
                .Include(user => user.FavoriteArtists)
                .FirstOrDefaultAsync(user => user.Id == userId) ?? throw new Exception();

            user.FavoriteArtists.Add(artist);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFavoriteAlbum(Guid userId, Guid albumId)
        {
            var album = await _context.Albums.FindAsync(albumId) ?? throw new Exception();
            var user = await _context.Users
                .Include(user => user.FavoriteAlbums)
                .FirstOrDefaultAsync(user => user.Id == userId) ?? throw new Exception();

            user.FavoriteAlbums.Remove(album);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFavoriteArtist(Guid userId, Guid artistId)
        {
            var artist = await _context.Artists.FindAsync(artistId) ?? throw new Exception();
            var user = await _context.Users
                .Include(user => user.FavoriteArtists)
                .FirstOrDefaultAsync(user => user.Id == userId) ?? throw new Exception();

            user.FavoriteArtists.Remove(artist);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}