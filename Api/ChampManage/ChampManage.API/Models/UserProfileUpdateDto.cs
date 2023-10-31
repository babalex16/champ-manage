namespace ChampManage.API.Models
{
    public class UserProfileUpdateDto
    {
        public DateTime? Birthdate { get; set; }
        public Gender Gender { get; set; }
        public BeltNames Belt { get; set; }
        public string Phone { get; set; }
        public int Weight { get; set; }
    }

}
