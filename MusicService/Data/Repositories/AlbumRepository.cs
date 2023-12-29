using MusicService.Models;

namespace MusicService.Data.Repositories
{
    public class AlbumRepository : IRepository<Album>
    {
        private readonly MusicDbContext _context;

        public AlbumRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<Album> Add(Album album)
        {
            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();

            return album;
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

        public async Task<Album> Get(Guid id)
        {
            return await _context.Albums.FindAsync(id);
        }

        public IEnumerable<Album> GetAll()
        {
            return _context.Albums;
        }

        public async Task<Album> Update(Album album)
        {
            _context.Albums.Update(album);
            await _context.SaveChangesAsync();

            return album;
        }
    }
}
