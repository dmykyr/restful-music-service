using MusicService.Models;

namespace MusicService.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> Get(Guid id);
        public Task<User> Get(string id);

        public Task<User> Add(User entity);

        public Task<User> Update(User entity);

        public Task<User> Delete(Guid id);

        public Task<IEnumerable<Album>> GetFavoriteAlbums(Guid userId, string searchName);

        public Task<IEnumerable<Artist>> GetFavoriteArtists(Guid userId, string searchName);

        public Task AddFavoriteAlbum(Guid userId, Guid albumId);

        public Task AddFavoriteArtist(Guid userId, Guid artistId);

        public Task RemoveFavoriteAlbum(Guid userId, Guid albumId);

        public Task RemoveFavoriteArtist(Guid userId, Guid artistId);
    }
}
