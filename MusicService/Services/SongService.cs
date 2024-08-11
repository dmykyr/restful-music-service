using AutoMapper;
using MusicService.DTOs;
using MusicService.Interfaces;
using MusicService.Models;
using MusicService.Responses;

namespace MusicService.Services
{
    public class SongService
    {
        private readonly IMapper _mapper;
        private readonly ISongRepository _songRepository;

        public SongService(ISongRepository songRepository, IMapper mapper)
        {
            _songRepository = songRepository;
            _mapper = mapper;
        }

        public  async Task<IEnumerable<SongResponse>> Search(string searchName) 
        {
            var songs = await _songRepository.GetMany(song => song.Title.Contains(searchName));
            return _mapper.Map<IEnumerable<SongResponse>>(songs);
        }

        public async Task<SongResponse> Get(Guid id)
        {
            var song = await _songRepository.Get(id);
            return _mapper.Map<SongResponse>(song);
        }

        public async Task<SongResponse> Add(CreateSongDTO songDTO)
        {
            var songEntity = new Song() { Title = songDTO.Title };
            songEntity.Image = Convert.FromBase64String(songDTO.Base64Image);
            songEntity.Track = Convert.FromBase64String(songDTO.Base64Track);
            songEntity.PublishingDate = DateTime.Now;

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
            song.PublishingDate = songDTO.PublishingDate ?? song.PublishingDate;
            song.Image = String.IsNullOrEmpty(songDTO.Base64Image) ?
                 song.Image : Convert.FromBase64String(songDTO.Base64Image);

            await _songRepository.Update(song);
            return _mapper.Map<SongResponse>(song);
        }

        public async Task Delete(Guid id)
        {
            await _songRepository.Delete(id);
        }
    }
}
