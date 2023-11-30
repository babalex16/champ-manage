using System.ComponentModel.DataAnnotations;

namespace ChampManage.API.Models.UserModels
{
    /// <summary>
    /// Data transfer object for user registration to a category of championship.
    /// </summary>
    public class UserCategoryRegistrationDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int ChampionshipId { get; set; }

    }

}
