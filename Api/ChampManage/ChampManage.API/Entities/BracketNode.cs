using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChampManage.API.Entities
{
    [Table("Matches")]
    public class BracketNode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Round { get; set; }
        public int Order {  get; set; }

        [ForeignKey("Participant1Id")]
        public User? Participant1 { get; set; }
        public int? Participant1Id { get; set; }

        [ForeignKey("Participant2Id")]
        public User? Participant2 { get; set; }
        public int? Participant2Id { get; set; }

        public ChampionshipCategory ChampionshipCategory { get; set; }
        public int ChampionshipCategoryId { get; set; }

        public bool? IsParticipant1Winner { get; set; }
        public BracketNode? LeftChild { get; set; }
        public int? LeftChildId { get; set; }
        public BracketNode? RightChild { get; set; }
        public int? RightChildId { get; set; }
    }
}
