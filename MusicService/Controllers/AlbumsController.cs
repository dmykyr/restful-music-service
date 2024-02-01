using Microsoft.AspNetCore.Mvc;
using MusicService.DTOs;
using MusicService.Responses;
using MusicService.Services;

namespace MusicService.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly AlbumService _albumService;

        public AlbumsController(AlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public async Task<IEnumerable<AlbumResponse>> GetAllAlbums()
        {
            return await _albumService.GetAll();
        }

        [HttpGet("{albumId}")]
        public async Task<AlbumResponse> GetAlbumById(Guid albumId)
        {
            return await _albumService.Get(albumId);
        }

        [HttpPost]
        public async Task<AlbumResponse> AddAlbum([FromBody] CreateAlbumDTO body)
        {
            return await _albumService.Add(body);
        }

        [HttpPatch("{albumId}")]
        public async Task<AlbumResponse> UpdateAlbum(Guid albumId, [FromBody] UpdateAlbumDTO body)
        {
            return await _albumService.Update(albumId, body);
        }

        [HttpDelete("{albumId}")]
        public async Task<AlbumResponse> DeleteAlbum(Guid albumId)
        {
            return await _albumService.Delete(albumId);
        }
    }
}
