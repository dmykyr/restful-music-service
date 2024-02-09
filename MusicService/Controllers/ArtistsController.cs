using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<ArtistResponse>> GetAllArtists([FromQuery] string searchName)
        {
            return await _artistService.GetAllArtists(searchName);
        }

        [HttpGet("{artistId}")]
        public async Task<ArtistResponse> GetArtist(Guid artistId)
        {
            return await _artistService.Get(artistId);
        }

        [HttpGet("{artistId}/albums")]
        public async Task<IEnumerable<AlbumResponse>> GetArtistAlbums(Guid artistId)
        {
            return await _artistService.GetArtistAlbums(artistId);
        }

        [HttpGet("{artistId}/albums")]
        public async Task<IEnumerable<SongResponse>> GetArtistSongs(Guid artistId)
        {
            return await _artistService.GetArtistSongs(artistId);
        }
    }
}
