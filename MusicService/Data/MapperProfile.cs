using AutoMapper;
using MusicService.DTOs;
using MusicService.Models;
using MusicService.Responses;

namespace MusicService.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ArtistDTO, Artist>();
            CreateMap<Artist, ArtistResponse>();

            CreateMap<CreateAlbumDTO, Album>();
            CreateMap<UpdateAlbumDTO, Album>();
            CreateMap<Album, AlbumResponse>();

            CreateMap<CreateSongDTO, Song>();
            CreateMap<UpdateSongDTO, Song>();
            CreateMap<Song, SongResponse>();
        }
    }
}
