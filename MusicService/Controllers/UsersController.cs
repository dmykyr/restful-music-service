using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicService.DTOs;
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

        [HttpPost("register")]
        public async Task<string> Register(RegistrationDTO registrationDTO)
        {
            return await _userService.Register(registrationDTO);
        }

        [HttpPost("login")]
        public async Task<string> Login(LoginDTO loginDTO)
        {
            return await _userService.Login(loginDTO);
        }

        [Authorize]
        [HttpGet("{userId}")]
        public async Task<UserResponse> GetMe (Guid userId)
        {
            return await _userService.Get(userId);
        }

        [Authorize]
        [HttpGet("{userId}/favorites/albums")]
        public async Task<IEnumerable<AlbumResponse>> GetFavoriteAlbums (Guid userId, [FromQuery] string searchName)
        {
            return await _userService.GetFavoriteAlbums(userId, searchName);
        }

        [Authorize]
        [HttpPost("{userId}/favorites/albums")]
        public async Task AddFavoriteAlbum (Guid userId, [FromBody] Guid albumId)
        {
            await _userService.AddFavoriteAlbum(userId, albumId);
        }

        [Authorize]
        [HttpDelete("{userId}/favorites/albums/{albumId}")]
        public async Task RemoveFavoriteAlbum(Guid userId, Guid albumId)
        {
            await _userService.RemoveFavoriteAlbum(userId, albumId);
        }

        [Authorize]
        [HttpGet("{userId}/favorites/artists")]
        public async Task<IEnumerable<ArtistResponse>> GetFavoriteArtists(Guid userId, [FromQuery] string searchName)
        {
            return await _userService.GetFavoriteArtists(userId, searchName);
        }

        [Authorize]
        [HttpPost("{userId}/favorites/artists")]
        public async Task AddFavoriteArtist(Guid userId, [FromBody] Guid artistId)
        {
            await _userService.AddFavoriteArtist(userId, artistId);
        }

        [Authorize]
        [HttpDelete("{userId}/favorites/artists/{artistId}")]
        public async Task RemoveFavoriteArtist(Guid userId, Guid artistId)
        {
            await _userService.RemoveFavoriteArtist(userId, artistId);
        }
    }
}
