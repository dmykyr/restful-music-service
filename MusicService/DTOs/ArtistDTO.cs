using System.ComponentModel.DataAnnotations;

namespace MusicService.DTOs
{
    public class ArtistDTO
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public string Base64Image { get; set; }
    }
}
