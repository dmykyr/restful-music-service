using System.ComponentModel.DataAnnotations;

namespace MusicService.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
