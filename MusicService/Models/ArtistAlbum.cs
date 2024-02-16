using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicService.Models
{
    [Keyless]
    public class ArtistAlbum
    {
        [Required]
        public Guid ArtistId { get; set; }

        [Required]
        public Guid AlbumId { get; set; }

        [ForeignKey("AlbumId")]
        public Album Album { get; set; }

        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
    }
}
