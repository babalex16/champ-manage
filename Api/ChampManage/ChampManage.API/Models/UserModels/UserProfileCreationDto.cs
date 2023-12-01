using System.ComponentModel.DataAnnotations;

namespace ChampManage.API.Models.UserModels
{
    /// <summary>
    /// Data transfer object used to update data necessary for championship registration
    /// </summary>
    public class UserProfileCreationDto
    {
        [Required(ErrorMessage = "Birthdate is required")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Belt is required")]
        public BeltNames Belt { get; set; }

        [Required]
        [Range(0, 200, ErrorMessage = "Weight must be a number between 0 and 200 kg")]
        public int Weight { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "TeamName cannot exceed 100 characters")]
        public string? TeamName { get; set; }

        [Phone]
        public string Phone { get; set; } = string.Empty;
    }


}
