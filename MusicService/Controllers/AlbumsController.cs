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
        public async Task<IEnumerable<AlbumResponse>> GetAll([FromQuery] string? searchName)
        {
            return await _albumService.GetAll(searchName);
        }

        [HttpGet("{albumId}")]
        public async Task<AlbumResponse> Get(Guid albumId)
        {
            return await _albumService.Get(albumId);
        }

        [HttpPost]
        public async Task<AlbumResponse> Create([FromBody] CreateAlbumDTO albumDTO)
        {
            return await _albumService.Create(albumDTO);
        }

        [HttpPatch("{albumId}")]
        public async Task<AlbumResponse> Update(Guid albumId, [FromBody] UpdateAlbumDTO albumDTO)
        {
            return await _albumService.Update(albumId, albumDTO);
        }

        [HttpDelete("{albumId}")]
        public async Task Delete(Guid albumId, [FromQuery] Guid artistId)
        {
            await _albumService.Delete(albumId, artistId);
        }

        [HttpGet("{albumId}/songs")]
        public async Task<IEnumerable<SongResponse>> GetAlbumSongs (Guid albumId)
        {
            return await _albumService.GetAlbumSongs(albumId);
        }

        [HttpPost("{albumId}/attach/{songId}")]
        public async Task AttachSongToAlbum (Guid albumId, Guid songId)
        {
            await _albumService.AttachSongToAlbum(albumId, songId);
        }

        [HttpDelete("{albumId}/songs/{songId}")]
        public async Task UnattachSongToAlbum(Guid albumId, Guid songId, [FromQuery] Guid artistId)
        {
            await _albumService.UnattachSongToAlbum(albumId, songId, artistId);
        }
    }
}
