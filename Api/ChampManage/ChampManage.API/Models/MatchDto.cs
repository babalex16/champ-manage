namespace ChampManage.API.Models
{
    public class MatchDto
    {
        public int Id { get; set; }
        public int Participant1Id { get; set; }
        public int Participant2Id { get; set; }
        public int WinnerId { get; set; }
        public int ChampionshipId { get; set; }
    }

}
