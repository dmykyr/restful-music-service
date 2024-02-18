using MusicService.Models;
using Microsoft.EntityFrameworkCore;

namespace MusicService.Data.Repositories
{ 
    public class AlbumRepository
    {
        private readonly MusicDbContext _context;

        public AlbumRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Album>> GetAll(string searchName)
        {
            IQueryable<Album> albums = _context.Albums;

            if (!String.IsNullOrEmpty(searchName))
            {
                albums = albums.Where(a => a.Title.Contains(searchName));
            }

            var result = await albums.ToListAsync();
            return result;
        }

        public async Task<Album> Get(Guid id)
        {
            return await _context.Albums.FindAsync(id) ?? throw new Exception();
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

        public async Task Delete(Guid id)
        {
            var album = await _context.Albums.FindAsync(id);

            if (album == null)
            {
                throw new Exception();
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Song>> GetAlbumSongs(Guid albumId)
        {
            var album = await _context.Albums
                .Include(album => album.Songs)
                .FirstOrDefaultAsync(album => album.Id == albumId) ?? throw new Exception();
            return album.Songs;
        }

        public async Task AttachSongToAlbum(Guid albumId, Guid songId)
        {
            var album = await _context.Albums
                .Include(a => a.Songs)
                .FirstOrDefaultAsync(album => album.Id == albumId) ?? throw new Exception();

            var song = await _context.Songs.FirstOrDefaultAsync(song => song.Id == songId) ?? throw new Exception();

            album.Songs.Add(song);
            _context.Albums.Update(album);
            await _context.SaveChangesAsync();
        }

        public async Task UnattachSongToAlbum(Guid albumId, Guid songId)
        {
            var album = await _context.Albums.FirstOrDefaultAsync(album => album.Id == albumId) ?? throw new Exception();

            var song = await _context.Songs.FirstOrDefaultAsync(song => song.Id == songId) ?? throw new Exception();

            album.Songs.Remove(song);
            _context.Albums.Update(album);
            await _context.SaveChangesAsync();
        }

        public async Task AttachAlbumToArtist(Guid albumId, Guid artistId)
        {
            var album = await _context.Albums.FirstOrDefaultAsync(a => a.Id == albumId) ?? throw new Exception();

            var artist = await _context.Artists.Include(a => a.Albums)
                .FirstOrDefaultAsync(a => a.Id == artistId) ?? throw new Exception();

            artist.Albums.Add(album);
            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();
        }

        public async Task UnattachAlbumToArtist(Guid albumId, Guid artistId)
        {
            var album = await _context.Albums.FirstOrDefaultAsync(a => a.Id == albumId) ?? throw new Exception();

            var artist = await _context.Artists.Include(a => a.Albums)
                .FirstOrDefaultAsync(a => a.Id == artistId) ?? throw new Exception();

            artist.Albums.Remove(album);
            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();
        }
    }
}
