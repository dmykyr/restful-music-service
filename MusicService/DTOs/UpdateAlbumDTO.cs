using System.ComponentModel.DataAnnotations;

namespace MusicService.DTOs
{
    public class UpdateAlbumDTO
    {
        public Guid? PublisherId { get; set; }

        [MaxLength(50)]
        public string? Title { get; set; }

        public string? Base64Image { get; set; }

        public DateTime? PublishingDate { get; set; }
    }
}
