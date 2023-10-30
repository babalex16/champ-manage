using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChampManage.API.Entities
{
    [NotMapped]
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Participant1Id")]
        public User? Participant1 { get; set; }
        public int Participant1Id { get; set; }

        [ForeignKey("Participant2Id")]
        public User? Participant2 { get; set; }
        public int Participant2Id { get; set; }

        [ForeignKey("WinnerId")]
        public User? Winner { get; set; }
        public int WinnerId { get; set; }

        [ForeignKey("ChampionshipId")]
        public Championship? Championship { get; set; }
        public int ChampionshipId { get; set; }
    }
}
