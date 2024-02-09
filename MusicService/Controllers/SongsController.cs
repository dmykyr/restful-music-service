using Microsoft.AspNetCore.Mvc;
using MusicService.DTOs;
using MusicService.Responses;
using MusicService.Services;

namespace MusicService.Controllers
{
    [Route("api/songs")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly SongService _songService;

        public SongsController(SongService songService)
        {
            _songService = songService;
        }

        [HttpPost]
        public async Task<SongResponse> CreateSong([FromBody] CreateSongDTO songDTO)
        {
            return await _songService.Add(songDTO);
        }

        [HttpPatch("{songId}")]
        public async Task<SongResponse> UpdateSong(Guid songId, [FromBody] UpdateSongDTO songDTO)
        {
            return await _songService.Update(songId, songDTO);
        }

        [HttpDelete("{songId}")]
        public async Task DeleteSong(Guid songId)
        {
            await _songService.Delete(songId);
        }
    }
}
