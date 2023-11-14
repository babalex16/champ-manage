using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChampManage.API.Entities
{
    public class UserCategoryRegistration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey("ChampionshipId")]
        public int ChampionshipId { get; set; }
        public Championship Championship { get; set; }
    }
}
