using Microsoft.AspNetCore.Mvc;
using MusicService.DTO;
using MusicService.DTOs;
using MusicService.Responses;
using MusicService.Services;

namespace MusicService.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ArtistService _artistService;
        private readonly UserService _userService;
        private readonly SongService _songService;

        public AdminController(
            ArtistService artistService, 
            UserService userService, 
            SongService songService)
        {
            _artistService = artistService;
            _userService = userService;
            _songService = songService;
        }

        [HttpPost("/artists")]
        public async Task<ArtistResponse> CreateArtist (ArtistDTO artistDTO)
        {
            return await _artistService.Add(artistDTO);
        }

        [HttpPost("/albums")]
        public async Task<SongResponse> CreateAlbum (CreateSongDTO songDTO)
        {
            return await _songService.Add(songDTO);
        }

        [HttpPost("/users")]
        public async Task<UserResponse> CreateUser (CreateUserDTO userDTO)
        {
            return await _userService.Create(userDTO);
        }
    }
}
