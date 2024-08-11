using MusicService.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MusicService.Interfaces;

namespace MusicService.Data.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly MusicDbContext _context;

        public SongRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Song>> GetMany(Expression<Func<Song, bool>> predicate) => 
            await _context.Songs.Where(predicate).ToListAsync();

        public async Task<Song> Get(Guid id) => 
            await _context.Songs.FindAsync(id) ?? throw new Exception();

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
            var song = await _context.Songs.FindAsync(id) ?? throw new Exception();

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
        }
    }
}
