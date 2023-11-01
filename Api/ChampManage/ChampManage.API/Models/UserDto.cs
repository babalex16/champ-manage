namespace ChampManage.API.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public int Weight { get; set; }
        public BeltNames Belt { get; set; }
        public string Phone { get; set; } = string.Empty;
        public UserType UserType { get; set; }

        public ICollection<int> CreatedChampionships { get; set; }
                = new List<int>();

        public ICollection<int> RegisteredChampionships { get; set; }
               = new List<int>();

    }

}
