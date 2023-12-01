namespace ChampManage.API.Models.UserModels
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public int Weight { get; set; }
        public string Belt { get; set; } = BeltNames.White.ToString();
        public string Phone { get; set; } = string.Empty;

    }

}
