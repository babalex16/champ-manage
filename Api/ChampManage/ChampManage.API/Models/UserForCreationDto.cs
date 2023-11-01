using System.ComponentModel.DataAnnotations;

namespace ChampManage.API.Models
{
    public class UserForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;
    }
}
