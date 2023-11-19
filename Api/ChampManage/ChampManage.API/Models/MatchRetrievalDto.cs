namespace ChampManage.API.Models
{
    public class MatchRetrievalDto
    {
        public int Order { get; set; }

        // Participants
        public string Participant1FullName { get; set; } = string.Empty;
        public string Participant1TeamName { get; set; } = string.Empty;
        public int? Participant1Age { get; set; }

        public string Participant2FullName { get; set; } = string.Empty;
        public string Participant2TeamName { get; set; } = string.Empty;
        public int? Participant2Age { get; set; }

        // Winner
        public bool? IsParticipant1Winner { get; set; }

    }
}
