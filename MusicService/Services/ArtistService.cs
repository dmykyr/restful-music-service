using AutoMapper;
using MusicService.Data.Repositories;
using MusicService.DTO;
using MusicService.Models;
using MusicService.Responses;

namespace MusicService.Services
{
    public class ArtistService
    {
        private readonly IMapper _mapper;
        private readonly ArtistRepository _artistRepository;
        private readonly AlbumRepository _albumRepository;

        public ArtistService(
            IMapper mapper, 
            ArtistRepository musicRepository, 
            AlbumRepository albumRepository
        )
        {
            _mapper = mapper;
            _artistRepository = musicRepository;
            _albumRepository = albumRepository;
        }

        public async Task<IEnumerable<ArtistResponse>> GetAllArtists(string searchName)
        {
            var artists = await _artistRepository.GetAll(searchName);
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

        public async Task<IEnumerable<AlbumResponse>> GetArtistAlbums(Guid artistId)
        {
            var artistAlbums = await _albumRepository.GetArtistAlbums(artistId);
            return _mapper.Map<IEnumerable<AlbumResponse>>(artistAlbums);
        }

        public async Task<IEnumerable<SongResponse>> GetArtistSongs(Guid artistId)
        {
            var artistSongs = await _artistRepository.GetArtistSongs(artistId);
            return _mapper.Map<IEnumerable<SongResponse>>(artistSongs);
        }
    }
}
