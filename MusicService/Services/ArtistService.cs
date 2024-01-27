using AutoMapper;
using MusicService.Data.Repositories;
using MusicService.DTO;
using MusicService.Models;
using MusicService.Responses;

namespace MusicService.Services
{
    public class ArtistService
    {
        private readonly ArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        public ArtistService(ArtistRepository musicRepository, IMapper mapper)
        {
            _artistRepository = musicRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArtistResponse>> GetAll()
        {
            var artists = await _artistRepository.GetAll();
            return _mapper.Map<IEnumerable<ArtistResponse>>(artists);
        }

        public async Task<ArtistResponse> Get(Guid id)
        {
            var artist = await _artistRepository.Get(id);
            return _mapper.Map<ArtistResponse>(artist);
        }

        public async Task<ArtistResponse> Add(ArtistDTO artistDTO)
        {
            var artistEntity = _mapper.Map<Artist>(artistDTO);
            var artistResponse = await _artistRepository.Add(artistEntity);
            return _mapper.Map<ArtistResponse>(artistResponse);
        }

        public async Task<ArtistResponse> Update(Guid id, ArtistDTO artistDTO)
        {
            var artist = await _artistRepository.Get(id);

            if (artist == null)
            {
                return null;
            }

            if(artistDTO.Name != artist.Name)
            {
                artist.Name = artistDTO.Name;
                await _artistRepository.Update(artist);
            }

            return _mapper.Map<ArtistResponse>(artist);
        }

        public async Task<ArtistResponse> Delete (Guid id)
        {
            var deletedArtist = await _artistRepository.Delete(id);
            return _mapper.Map<ArtistResponse>(deletedArtist);
        }
    }
}
