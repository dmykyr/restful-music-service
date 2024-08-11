using MusicService.Models;
using System.Linq.Expressions;

namespace MusicService.Interfaces
{
    public interface IAlbumRepository
    {
        public Task<IEnumerable<Artist>> GetAll();

        public Task<IEnumerable<Album>> GetMany(Expression<Func<Album, bool>> predicate);

        public Task<Album> Get(Guid id);

        public Task<Album> Add(Album entity);

        public Task<Album> Update(Album entity);

        public Task Delete(Guid id);

        public Task<IEnumerable<Song>> GetAlbumSongs(Guid albumId);

        public Task AttachSongToAlbum(Guid albumId, Guid songId);

        public Task UnattachSongToAlbum(Guid albumId, Guid songId);

        public Task AttachAlbumToArtist(Guid albumId, Guid artistId);

        public Task UnattachAlbumToArtist(Guid albumId, Guid artistId);
    }
}
