using AutoMapper;
using MusicService.Data.Repositories;
using MusicService.DTOs;
using MusicService.Models;
using MusicService.Responses;

namespace MusicService.Services
{
    public class AlbumService
    {
        private readonly IMapper _mapper;
        private readonly AlbumRepository _albumRepository;
        private readonly ArtistRepository _artistRepository;

        public AlbumService(IMapper mapper, AlbumRepository albumRepository, ArtistRepository artistRepository)
        {
            _mapper = mapper;
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
        }

        public async Task<IEnumerable<AlbumResponse>> GetAll(string searchName)
        {
            var albums = await _albumRepository.GetAll(searchName);
            return _mapper.Map<IEnumerable<AlbumResponse>>(albums);
        }

        public async Task<AlbumResponse> Get(Guid id)
        {
            var album = await _albumRepository.Get(id);
            return _mapper.Map<AlbumResponse>(album);
        }

        public async Task<AlbumResponse> Update(Guid id, UpdateAlbumDTO albumDTO)
        {
            var album = await _albumRepository.Get(id);

            if (album == null)
            {
                return null;
            }

            album.Title = albumDTO.Title ?? album.Title;
            album.Base64Image = albumDTO.Base64Image ?? album.Base64Image;
            album.PublishingDate = albumDTO.PublishingDate ?? album.PublishingDate;

            await _albumRepository.Update(album);
            return _mapper.Map<AlbumResponse>(album);
        }

        public async Task Delete(Guid albumId)
        {
            await _albumRepository.Delete(albumId);
        }

        public async Task<IEnumerable<SongResponse>> GetAlbumSongs(Guid albumId)
        {
            var albumSongs = await _albumRepository.GetAlbumSongs(albumId);
            return _mapper.Map<IEnumerable<SongResponse>>(albumSongs);
        }

        public async Task AttachSongToAlbum(Guid albumId, Guid songId)
        {
            await _albumRepository.AttachSongToAlbum(albumId, songId);
        }

        public async Task UnattachSongToAlbum(Guid albumId, Guid songId)
        {
            await _albumRepository.UnattachSongToAlbum(albumId, songId);
        }
    }
}
