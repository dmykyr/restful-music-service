using Microsoft.AspNetCore.Mvc;
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
        public async Task<UserResponse> GetUserInfo (Guid userId)
        {
            return await _userService.Get(userId);
        }

        [HttpGet("{userId}/favorites/albums")]
        public async Task<IEnumerable<AlbumResponse>> GetFavoriteAlbums (Guid userId, [FromQuery] string searchName)
        {
            return await _userService.GetFavoriteAlbums(userId, searchName);
        }

        [HttpPost("{userId}/favorites/albums")]
        public async Task AddFavoriteAlbum (Guid userId, [FromBody] Guid albumId)
        {
            await _userService.AddFavoriteAlbum(userId, albumId);
        }

        [HttpDelete("{userId}/favorites/albums/{albumId}")]
        public async Task RemoveFavoriteAlbum(Guid userId, Guid albumId)
        {
            await _userService.RemoveFavoriteAlbum(userId, albumId);
        }

        [HttpGet("{userId}/favorites/artists")]
        public async Task<IEnumerable<ArtistResponse>> GetFavoriteArtists(Guid userId, [FromQuery] string searchName)
        {
            return await _userService.GetFavoriteArtists(userId, searchName);
        }

        [HttpPost("{userId}/favorites/artists")]
        public async Task AddFavoriteArtist(Guid userId, [FromBody] Guid artistId)
        {
            await _userService.AddFavoriteArtist(userId, artistId);
        }

        [HttpDelete("{userId}/favorites/artists/{artistId}")]
        public async Task RemoveFavoriteArtist(Guid userId, Guid artistId)
        {
            await _userService.RemoveFavoriteArtist(userId, artistId);
        }
    }
}
