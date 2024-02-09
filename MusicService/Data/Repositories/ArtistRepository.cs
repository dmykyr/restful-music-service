using MusicService.Models;
using System.Data.Entity;

namespace MusicService.Data.Repositories
{
    public class ArtistRepository
    {
        private readonly MusicDbContext _context;

        public ArtistRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Artist>> GetAll(string searchName)
        {
            return await _context.Artists.Where(a => a.Name.Contains(searchName)).ToListAsync();
        }

        public async Task<Artist> Get(Guid id)
        {
            return await _context.Artists.FindAsync(id);
        }
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
            return await _context.ArtistsSongs
                .Include(artistSong =>  artistSong.Song)
                .Where(artistSong => artistSong.ArtistId == artistId)
                .Select(artistSong => artistSong.Song)
                .ToListAsync();
        }
    }
}
