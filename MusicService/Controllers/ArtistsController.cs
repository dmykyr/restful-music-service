using Microsoft.AspNetCore.Mvc;
using MusicService.DTOs;
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
        public async Task<IEnumerable<ArtistResponse>> GetAllArtists([FromQuery] string? searchName)
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

        [HttpPost("{artistId}/albums")]
        public async Task<AlbumResponse> CreateArtistAlbum([FromBody] CreateAlbumDTO albumDTO, Guid artistId)
        {
            return await _artistService.CreateArtistAlbum(artistId, albumDTO);
        }

        [HttpDelete("{artistId}/albums/{albumId}")]
        public async Task DeleteArtistAlbum(Guid artistId, Guid albumId)
        {
            await _artistService.DeleteArtistAlbum(artistId, albumId);
        }

        [HttpGet("{artistId}/songs")]
        public async Task<IEnumerable<SongResponse>> GetArtistSongs(Guid artistId)
        {
            return await _artistService.GetArtistSongs(artistId);
        }
    }
}
