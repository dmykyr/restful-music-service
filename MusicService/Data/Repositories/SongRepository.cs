using MusicService.Models;
using System.Data.Entity;

namespace MusicService.Data.Repositories
{
    public class SongRepository : IRepository<Song>
    {
        private readonly MusicDbContext _context;

        public SongRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Song>> GetAll()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task<Song> Get(Guid id)
        {
            return await _context.Songs.FindAsync(id);
        }

        public async Task<Song> Add(Song entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Song> Update(Song entity)
        {
            _context.Songs.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        
        public async Task<Song> Delete(Guid id)
        {
            var song = await _context.Songs.FindAsync(id);

            if (song != null)
            {
                _context.Songs.Remove(song);
                await _context.SaveChangesAsync();

                return song;
            }

            throw new NotImplementedException();
        }
    }
}
