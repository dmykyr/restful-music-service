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
            return await _context.ArtistAlbums
                .Include(aa => aa.Album)
                .Where(aa => aa.ArtistId == artistId)
                .Select(aa => aa.Album)
                .ToListAsync();
        }

        public async Task<IEnumerable<Song>> GetAlbumSongs(Guid albumId)
        {
            return await _context.AlbumSongs
                .Include(albumSong => albumSong.Song)
                .Where(albumSong => albumSong.AlbumId == albumId)
                .Select(albumSong => albumSong.Song)
                .ToListAsync();
        }

        public async Task AttachSongToAlbum(Guid albumId, Guid songId)
        {
            var albumSong = new AlbumSong() { AlbumId = albumId, SongId = songId };
            await _context.AlbumSongs.AddAsync(albumSong);
            await _context.SaveChangesAsync();
        }

        public async Task UnattachSongToAlbum(Guid albumId, Guid songId)
        {
            var albumSong = _context.AlbumSongs
                .FirstOrDefault(albumSong => albumSong.SongId == songId && albumSong.AlbumId == albumId);
            if (albumSong == null) throw new Exception();

            _context.AlbumSongs.Remove(albumSong);
            await _context.SaveChangesAsync();
            
        }
    }
}
