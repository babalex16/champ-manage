namespace ChampManage.API.Models
{
    public class UserPublicDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string TeamName { get; set; }
        public int Weight { get; set; }
        public int Belt { get; set; }
    }
}
