using Microsoft.AspNetCore.Mvc;
using MusicService.DTOs;
using MusicService.Responses;
using MusicService.Services;
using System.Runtime.InteropServices;

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
        public async Task<IEnumerable<AlbumResponse>> GetAll([FromQuery] string? searchName)
        {
            return await _albumService.GetAll(searchName);
        }

        [HttpGet("{albumId}")]
        public async Task<AlbumResponse> Get(Guid albumId)
        {
            return await _albumService.Get(albumId);
        }

        [HttpPatch("{albumId}")]
        public async Task<AlbumResponse> Update(Guid albumId, [FromBody] UpdateAlbumDTO albumDTO)
        {
            return await _albumService.Update(albumId, albumDTO);
        }

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

        [HttpPost("{albumId}/songs/{songId}")]
        public async Task<IActionResult> AttachSongToAlbum (Guid albumId, Guid songId)
        {
            await _albumService.AttachSongToAlbum(albumId, songId);
            return Ok();
        }

        [HttpDelete("{albumId}/songs/{songId}")]
        public async Task UnattachSongToAlbum(Guid albumId, Guid songId)
        {
            await _albumService.UnattachSongToAlbum(albumId, songId);
        }
    }
}
