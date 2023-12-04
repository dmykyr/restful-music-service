using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicService.Models
{
    public class ArtistSong
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ArtistId { get; set; }

        [Required]
        public Guid SongId { get; set; }

        public Guid? AlbumId { get; set; }

        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }

        [ForeignKey("SongId")]
        public Song Song { get; set; }

        [ForeignKey("AlbumId")]
        public Album Album { get; set; }
    }
}
