using AutoMapper;
using MusicService.Data.Repositories;
using MusicService.DTOs;
using MusicService.Models;
using MusicService.Responses;

namespace MusicService.Services
{
    public class SongService
    {
        private readonly IRepository<Song> _songRepository;
        private readonly IMapper _mapper;

        public SongService(IRepository<Song> songRepository, IMapper mapper)
        {
            _songRepository = songRepository;
            _mapper = mapper;
        }

        public  async Task<IEnumerable<SongResponse>> GetAll() 
        {
            var songs = await _songRepository.GetAll();
            return _mapper.Map<IEnumerable<SongResponse>>(songs);
        }

        public async Task<SongResponse> Get(Guid id)
        {
            var song = await _songRepository.Get(id);
            return _mapper.Map<SongResponse>(song);
        }

        public async Task<SongResponse> Add(CreateSongDTO songDTO)
        {
            var songEntity = _mapper.Map<Song>(songDTO);
            var createdSong = await _songRepository.Add(songEntity);
            return _mapper.Map<SongResponse>(createdSong);
        }

        public async Task<SongResponse> Update(Guid id, UpdateSongDTO songDTO)
        {
            var song = await _songRepository.Get(id);

            if(song == null)
            {
                return null;
            }

            song.Title = songDTO.Title ?? song.Title;
            song.Track = songDTO.Track ?? song.Track;
            song.PublishingDate = songDTO.PublishingDate ?? song.PublishingDate;

            await _songRepository.Update(song);
            return _mapper.Map<SongResponse>(song);
        }

        public async Task<SongResponse> Delete(Guid id)
        {
            var deletedSong = await _songRepository.Delete(id);
            return _mapper.Map<SongResponse>(deletedSong);
        }
    }
}
