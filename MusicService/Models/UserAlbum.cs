using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicService.Models
{
    [Keyless]
    public class UserAlbum
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid AlbumId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("AlbumId")]
        public Album Album { get; set; }
    }
}
