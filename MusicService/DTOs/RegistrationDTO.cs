using System.ComponentModel.DataAnnotations;

namespace MusicService.DTOs
{
    public class RegistrationDTO
    {
        [Required]
        [MaxLength(50)]
        public string Nickname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
