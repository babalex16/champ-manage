using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChampManage.API.Entities
{
    public class ChampionshipCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ChampionshipId")]
        public int ChampionshipId { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        // Navigation properties to Championship and Category entities
        public Championship Championship { get; set; }
        public Category Category { get; set; }
    }

}
