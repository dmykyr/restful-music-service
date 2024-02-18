using Azure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicService.Models
{
    public class Artist
    {
        [Key]
        public Guid Id { get; set; }
        
        public Guid? UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Base64Image { get; set; }

        public ICollection<Album> Albums { get; set; }


        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<User> UserFans { get; set; }
    }
}
