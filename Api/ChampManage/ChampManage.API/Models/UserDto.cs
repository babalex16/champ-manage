namespace ChampManage.API.Models
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string? TeamName { get; set; }
        public int Weight { get; set; }
        public BeltNames Belt { get; set; }
        public string? Phone { get; set; }
        public UserType UserType { get; set; }
    }

}
