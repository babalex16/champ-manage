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
        public Championship Championship { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<BracketNode> CategoryMatches { get; set; } = new List<BracketNode>();

    }

}
