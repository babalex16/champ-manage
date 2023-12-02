namespace ChampManage.API.Models.MatchModels
{
    /// <summary>
    /// Data Transfer Object used to display matches
    /// </summary>

    public class MatchRetrievalDto
    {
        // Category
        public string CategoryName { get; set; } = string.Empty;
        public string Belt { get; set; }
        public int MaxWeight { get; set; }
        public int FightTimeMinutes { get; set; }
        public int Round {  get; set; }
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
