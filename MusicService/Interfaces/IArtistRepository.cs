using MusicService.Models;
using System.Linq.Expressions;

namespace MusicService.Interfaces
{
    public interface IArtistRepository
    {
        public Task<IEnumerable<Artist>> GetAll();

        public Task<IEnumerable<Artist>> GetMany(Expression<Func<Artist, bool>> predicate);

        public Task<Artist> Get(Guid id);

        public Task<Artist> Add(Artist entity);

        public Task<Artist> Update(Artist entity);

        public Task<Artist> Delete(Guid id);

        public Task<IEnumerable<Song>> GetArtistSongs(Guid artistId);

        public Task<IEnumerable<Album>> GetArtistAlbums(Guid artistId);
    }
}
