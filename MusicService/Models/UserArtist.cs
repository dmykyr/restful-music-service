using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicService.Models
{
    public class UserArtist
    {
        [Key]
        [Column(Order = 0)]
        public Guid UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid ArtistId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
    }
}
