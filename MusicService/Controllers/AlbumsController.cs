using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicService.DTOs;
using MusicService.Responses;
using MusicService.Services;

namespace MusicService.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly AlbumService _albumService;

        public AlbumController(AlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public async Task<IEnumerable<AlbumResponse>> GetAlbums([FromQuery] string? searchName)
        {
            var artists = string.IsNullOrEmpty(searchName)
                ? await _albumService.GetAll()
                : await _albumService.Search(searchName);

            return artists;
        }

        [HttpGet("{albumId}")]
        public async Task<AlbumResponse> GetAlbum(Guid albumId)
        {
            return await _albumService.Get(albumId);
        }

        [Authorize]
        [HttpPatch("{albumId}")]
        public async Task<AlbumResponse> Update(Guid albumId, [FromBody] UpdateAlbumDTO albumDTO)
        {
            return await _albumService.Update(albumId, albumDTO);
        }

        [Authorize]
        [HttpDelete("{albumId}")]
        public async Task Delete(Guid albumId)
        {
            await _albumService.Delete(albumId);
        }

        [HttpGet("{albumId}/songs")]
        public async Task<IEnumerable<SongResponse>> GetAlbumSongs (Guid albumId)
        {
            return await _albumService.GetAlbumSongs(albumId);
        }

        [Authorize]
        [HttpPost("{albumId}/songs/{songId}")]
        public async Task<IActionResult> AttachSongToAlbum (Guid albumId, Guid songId)
        {
            await _albumService.AttachSongToAlbum(albumId, songId);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{albumId}/songs/{songId}")]
        public async Task UnattachSongToAlbum(Guid albumId, Guid songId)
        {
            await _albumService.UnattachSongToAlbum(albumId, songId);
        }
    }
}
