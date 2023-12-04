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
    }
}
