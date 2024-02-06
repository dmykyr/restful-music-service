using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicService.Models
{
    public class Album
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid PublisherId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Base64Image { get; set; }

        [Required]
        public DateTime PublishingDate { get; set; }

        [ForeignKey("PublisherId")]
        public Artist Publisher { get; set; }
    }
}
