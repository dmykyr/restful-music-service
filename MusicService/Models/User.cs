using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicService.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid AccountId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nickname { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}
