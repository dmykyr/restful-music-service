using Microsoft.AspNetCore.Mvc;
using MusicService.DTO;
using MusicService.Responses;
using MusicService.Services;

namespace MusicService.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ArtistService _artistService;

        public ArtistsController(ArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<IEnumerable<ArtistResponse>> GetAllSongs()
        {
            return await _artistService.GetAll();
        }

        [HttpGet("{artistId}")]
        public async Task<ArtistResponse> GetSongById(Guid songId)
        {
            return await _artistService.Get(songId);
        }

        [HttpPost]
        public async Task<ArtistResponse> AddSong([FromBody] ArtistDTO body)
        {
            return await _artistService.Add(body);
        }

        [HttpPatch("{artistId}")]
        public async Task<ArtistResponse> UpdateSong(Guid songId, [FromBody] ArtistDTO body)
        {
            return await _artistService.Update(songId, body);
        }

        [HttpDelete("{artistId}")]
        public async Task<ArtistResponse> DeleteSong(Guid songId)
        {
            return await _artistService.Delete(songId);
        }
    }
}
