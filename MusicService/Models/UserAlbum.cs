using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicService.Models
{
    public class UserAlbum
    {
        [Key]
        [Column(Order = 0)]
        public Guid UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid AlbumId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("AlbumId")]
        public Album Album { get; set; }
    }
}
