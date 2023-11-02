using System.ComponentModel.DataAnnotations;

namespace ChampManage.API.Models
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;
    }
}
