using MusicService.Models;
using System.Data.Entity;

namespace MusicService.Data.Repositories
{ 
    public class AlbumRepository
    {
        private readonly MusicDbContext _context;

        public AlbumRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Album>> GetAll()
        {
            return await _context.Albums.ToListAsync();
        }

        public async Task<Album> Get(Guid id)
        {
            return await _context.Albums.FindAsync(id);
        }

        public async Task<Album> Add(Album entity)
        {
            await _context.Albums.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Album> Update(Album entity)
        {
            _context.Albums.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Album> Delete(Guid id)
        {
            var album = await _context.Albums.FindAsync(id);

            if (album != null)
            {
                _context.Albums.Remove(album);
                await _context.SaveChangesAsync();

                return album;
            }

            throw new NotImplementedException();
        }

        public async Task<List<Album>> GetArtistAlbums (Guid artistId)
        {
            return await _context.Albums.Where(a => a.PublisherId == artistId).ToListAsync();
        }
    }
}
