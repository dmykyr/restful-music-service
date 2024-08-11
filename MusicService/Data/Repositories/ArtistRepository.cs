using MusicService.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MusicService.Interfaces;

namespace MusicService.Data.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly MusicDbContext _context;

        public ArtistRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Artist>> GetAll()
        {
            return await _context.Artists.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Artist>> GetMany(Expression<Func<Artist, bool>> predicate) =>  
            await _context.Artists.AsNoTracking().Where(predicate).ToListAsync();

        public async Task<Artist> Get(Guid id) => 
            await _context.Artists.FindAsync(id) ?? throw new Exception();

        public async Task<Artist> Add(Artist entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Artist> Update(Artist entity)
        {
            _context.Artists.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Artist> Delete(Guid id)
        {
            var artist = await _context.Artists.FindAsync(id);

            if (artist != null)
            {
                _context.Artists.Remove(artist);
                await _context.SaveChangesAsync();

                return artist;
            }

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Song>> GetArtistSongs(Guid artistId)
        {
            var artist = await _context.Artists
                .Include(artist => artist.Albums)
                .ThenInclude(album => album.Songs)
                .FirstOrDefaultAsync(a => a.Id == artistId) ?? throw new Exception();

            List<Song> songs = new List<Song>();
            foreach (var album in artist.Albums)
            {
                songs.AddRange(album.Songs);
            }

            return songs;
        }

        public async Task<IEnumerable<Album>> GetArtistAlbums(Guid artistId)
        {
            var artist = await _context.Artists
                .Include(a => a.Albums)
                .FirstOrDefaultAsync(a => a.Id == artistId) ?? throw new Exception();

            return artist.Albums;
        }
    }
}
