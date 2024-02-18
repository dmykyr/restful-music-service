using System.ComponentModel.DataAnnotations;

namespace MusicService.Models
{
    public class Album
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Base64Image { get; set; }

        [Required]
        public DateTime PublishingDate { get; set; }

        public ICollection<Artist> Artists { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
