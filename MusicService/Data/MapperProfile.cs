using AutoMapper;
using MusicService.DTO;
using MusicService.Models;
using MusicService.Responses;

namespace MusicService.Data
{
    public class MapperProfile : Profile
    {
        MapperProfile()
        {
            CreateMap<ArtistDTO, Artist>();
            CreateMap<Artist, ArtistResponse>();
        }
    }
}
