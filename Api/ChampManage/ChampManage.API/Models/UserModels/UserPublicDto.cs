namespace ChampManage.API.Models.UserModels
{
    /// <summary>
    /// Data transfer object having no sensitive data that could be shown in match views
    /// </summary>
    public class UserPublicDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string TeamName { get; set; } = string.Empty;
        public int Weight { get; set; }
        public string Belt { get; set; } = BeltNames.White.ToString();
    }
}
