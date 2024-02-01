using Microsoft.AspNetCore.Mvc;
using MusicService.DTO;
using MusicService.Models;
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
        public async Task<IEnumerable<ArtistResponse>> GetAllArtists()
        {
            return await _artistService.GetAll();
        }

        [HttpGet("{artistId}")]
        public async Task<ArtistResponse> GetArtistById(Guid artistId)
        {
            return await _artistService.Get(artistId);
        }

        [HttpPost]
        public async Task<ArtistResponse> AddArtist([FromBody] ArtistDTO body)
        {
            return await _artistService.Add(body);
        }

        [HttpPatch("{artistId}")]
        public async Task<ArtistResponse> UpdateArtist(Guid artistId, [FromBody] ArtistDTO body)
        {
            return await _artistService.Update(artistId, body);
        }

        [HttpDelete("{artistId}")]
        public async Task<ArtistResponse> DeleteArtist(Guid artistId)
        {
            return await _artistService.Delete(artistId);
        }
    }
}
