namespace ChampManage.API.Models.ChampionshipModels
{
    public class ChampionshipForRetrievalDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public decimal RegistrationFee { get; set; }
        public DateTime RegistrationDeadline { get; set; }
        public string? Description { get; set; }
    }
}
