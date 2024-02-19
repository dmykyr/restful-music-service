using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicService.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        public Guid? ArtistId { get; set; }

        [Required]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Nickname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("ArtistId")]
        public Artist? Artist { get; set; }

        public ICollection<Artist> FavoriteArtists { get; set; }

        public ICollection<Album> FavoriteAlbums { get; set; }
    }
}
