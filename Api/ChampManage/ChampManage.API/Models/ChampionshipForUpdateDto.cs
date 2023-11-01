using System.ComponentModel.DataAnnotations;

namespace ChampManage.API.Models
{
    public class ChampionshipForUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Location { get; set; } = string.Empty;

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DateTime { get; set; }

        [Required]
        public decimal RegistrationFee { get; set; }

        [Required]
        public DateTime RegistrationDeadline { get; set; }

        public string Description { get; set; } = string.Empty;

        [Required]
        public int OrganizerId { get; set; }
    }
}
