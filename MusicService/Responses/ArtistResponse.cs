using System.ComponentModel.DataAnnotations;

namespace MusicService.Responses
{
    public class ArtistResponse
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
