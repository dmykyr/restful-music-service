using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MusicService.Models
{
    [Keyless]
    public class UserArtist
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ArtistId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
    }
}
