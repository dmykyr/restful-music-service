using MusicService.Models;
using System.Linq.Expressions;

namespace MusicService.Interfaces
{
    public interface ISongRepository
    {
        public Task<IEnumerable<Song>> GetMany(Expression<Func<Song, bool>> predicate);

        public Task<Song> Get(Guid id);

        public Task<Song> Add(Song entity);

        public Task<Song> Update(Song entity);

        public Task Delete(Guid id);
    }
}
