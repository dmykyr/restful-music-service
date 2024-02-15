using MusicService.Models;
using Microsoft.EntityFrameworkCore;

namespace MusicService.Data.Repositories
{
    public class SongRepository
    {
        private readonly MusicDbContext _context;

        public SongRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Song>> GetAll(string searchName)
        {
            IQueryable<Song> songs = _context.Songs;

            if (!String.IsNullOrEmpty(searchName))
            {
                songs = songs.Where(a => a.Title.Contains(searchName));
            }

            var result = await songs.ToListAsync();
            return result;
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
        
        public async Task Delete(Guid id)
        {
            var song = await _context.Songs.FindAsync(id);

            if (song != null)
            {
                _context.Songs.Remove(song);
                await _context.SaveChangesAsync();
            }

            throw new NotImplementedException();
        }
    }
}
