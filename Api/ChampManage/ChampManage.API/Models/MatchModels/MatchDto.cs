namespace ChampManage.API.Models.MatchModels
{
    public class MatchDto
    {
        public int Id { get; set; }
        public int Order { get; set; }

        // Participants
        public int? Participant1Id { get; set; }

        public int? Participant2Id { get; set; }

        // Winner
        public bool? IsParticipant1Winner { get; set; }

        // Children Matches
        public int? LeftChildId { get; set; }
        public int? RightChildId { get; set; }
    }

}
