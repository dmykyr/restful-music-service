using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicService.Models
{
    [Keyless]
    public class AlbumSong
    {
        [Required]
        public Guid AlbumId { get; set; }

        [Required]
        public Guid SongId { get; set; }

        [ForeignKey("AlbumId")]
        public Album Album { get; set; }

        [ForeignKey("SongId")]
        public Song Song { get; set; }
    }
}
