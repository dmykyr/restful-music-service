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

        public async Task<IEnumerable<Album>> GetArtistAlbums(Guid artistId)
        {
            return await _context.Albums.Where(a => a.PublisherId == artistId).ToListAsync();
        }

        public async Task<IEnumerable<Song>> GetAlbumSongs(Guid albumId)
        {
            return await _context.ArtistsSongs
                .Include(artistSong => artistSong.Song)
                .Where(artistSong => artistSong.AlbumId == albumId)
                .Select(artistSong => artistSong.Song)
                .ToListAsync();
        }

        public async Task AttachSongToAlbum(Guid albumId, Guid songId)
        {
            var artistsSong = await _context.ArtistsSongs.Where(artistSong => artistSong.SongId == songId).ToListAsync();
            foreach (var artistSong in artistsSong)
            {
                artistSong.AlbumId = albumId;
                _context.ArtistsSongs.Update(artistSong);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UnattachSongToAlbum(Guid albumId, Guid songId)
        {
            var artistsSong = await _context.ArtistsSongs
                .Where(artistSong => artistSong.SongId == songId && artistSong.AlbumId == albumId)
                .ToListAsync();
            foreach (var artistSong in artistsSong)
            {
                artistSong.AlbumId = null;
                _context.ArtistsSongs.Update(artistSong);
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
