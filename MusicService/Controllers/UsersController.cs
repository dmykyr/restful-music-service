using Microsoft.AspNetCore.Mvc;
using MusicService.Models;
using MusicService.Responses;
using MusicService.Services;

namespace MusicService.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<UserResponse> GetUserById (Guid userId)
        {
            return await _userService.Get(userId);
        }

        [HttpGet("{userId}/favorites/albums")]
        public async Task<IEnumerable<AlbumResponse>> GetUserFavoriteAlbums (Guid userId)
        {
            return await _userService.GetFavoriteAlbums(userId);
        }

        [HttpGet("{userId}/favorites/artists")]
        public async Task<IEnumerable<ArtistResponse>> GetUserFavoriteArtists(Guid userId)
        {
            return await _userService.GetFavoriteArtists(userId);
        }

        [HttpDelete("{userId}/favorites/albums/{albumId}")]
        public async Task<AlbumResponse> RemoveFavoriteAlbum (Guid userId, Guid albumId)
        {
            return await _userService.RemoveFavoriteAlbum(userId, albumId);
        }

        [HttpDelete("{userId}/favorites/artists/{artistId}")]
        public async Task<ArtistResponse> RemoveFavoriteArtist(Guid userId, Guid artistId)
        {
            return await _userService.RemoveFavoriteArtist(userId, artistId);
        }
    }
}
