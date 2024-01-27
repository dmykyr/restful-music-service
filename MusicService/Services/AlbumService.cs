using AutoMapper;
using MusicService.Data.Repositories;
using MusicService.DTO;
using MusicService.DTOs;
using MusicService.Models;
using MusicService.Responses;

namespace MusicService.Services
{
    public class AlbumService
    {
        private readonly AlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public AlbumService(AlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AlbumResponse>> GetAll()
        {
            var albums = await _albumRepository.GetAll();
            return _mapper.Map<IEnumerable<AlbumResponse>>(albums);
        }

        public async Task<AlbumResponse> Get(Guid id)
        {
            var album = await _albumRepository.Get(id);
            return _mapper.Map<AlbumResponse>(album);
        }

        public async Task<AlbumResponse> Add(CreateAlbumDTO albumDTO)
        {
            var albumEntity = _mapper.Map<Album>(albumDTO);
            var createdAlbum = await _albumRepository.Add(albumEntity);
            return _mapper.Map<AlbumResponse>(createdAlbum);
        }

        public async Task<AlbumResponse> Update(Guid id, UpdateAlbumDTO albumDTO)
        {
            var album = await _albumRepository.Get(id);

            if (album == null)
            {
                return null;
            }

            album.Title = albumDTO.Title ?? album.Title;
            album.PublisherId = albumDTO.PublisherId ?? album.PublisherId;
            album.PublishingDate = albumDTO.PublishingDate ?? album.PublishingDate;

            await _albumRepository.Update(album);
            return _mapper.Map<AlbumResponse>(album);
        }

        public async Task<AlbumResponse> Delete(Guid id)
        {
            var deletedAlbum = await _albumRepository.Delete(id);
            return _mapper.Map<AlbumResponse>(deletedAlbum);
        }
    }
}
