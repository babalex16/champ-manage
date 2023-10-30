using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChampManage.API.Entities
{
    public class User
    {
        public User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

        [MaxLength(100)]
        public string? TeamName { get; set; }

        [Range(0, 200)]
        public int Weight { get; set; }

        public BeltNames Belt { get; set; } = BeltNames.White;

        [Phone]
        public string? Phone { get; set; }

        public UserType UserType { get; set; }

        // For Organizers
        public ICollection<Championship> CreatedChampionships { get; set; } 
            = new List<Championship>();
        
        // For Participants
        public ICollection<Championship> RegisteredChampionships { get; set; } 
            = new List<Championship>();
    }
}

namespace ChampManage.API
{   
    public enum Gender
    {
        Male,
        Female,
    }
    public enum BeltNames
    {
        White,
        Blue,
        Purple,
        Brown,
        Black
    }
    public enum UserType
    {
        Organizer,
        Participant
    }
}