using System.ComponentModel.DataAnnotations.Schema;
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
        public Guid ArtistId { get; set; }

        [Required]
        public Guid SongId { get; set; }

        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }

        [ForeignKey("SongId")]
        public Song Song { get; set; }
    }
}
