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
        readonly SongService _songService;
        SongsController(SongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public async Task<IEnumerable<SongResponse>> GetAllSongs()
        {
            return await _songService.GetAll();
        }

        [HttpGet("{songId}")]
        public async Task<SongResponse> GetSongById(Guid songId)
        {
            return await _songService.Get(songId);
        }

        [HttpPost]
        public async Task<SongResponse> AddSong([FromBody] CreateSongDTO body)
        {
            return await _songService.Add(body);
        }

        [HttpPatch("{songId}")]
        public async Task<SongResponse> UpdateSong(Guid songId, [FromBody] UpdateSongDTO body)
        {
            return await _songService.Update(songId, body);
        }

        [HttpDelete("{songId}")]
        public async Task<SongResponse> DeleteSong(Guid songId)
        {
            return await _songService.Delete(songId);
        }
    }
}