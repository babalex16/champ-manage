using System.ComponentModel.DataAnnotations;

namespace ChampManage.API.Models.AuthenticationModels
{
    /// <summary>
    /// Data transfer object for handling user's credentials
    /// </summary>
    public class LoginCredentialsDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;
    }
}
