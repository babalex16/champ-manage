using System.ComponentModel.DataAnnotations;

namespace ChampManage.API.Models
{
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
