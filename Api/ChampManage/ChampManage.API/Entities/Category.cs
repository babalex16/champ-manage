using System.ComponentModel.DataAnnotations;

namespace ChampManage.API.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, 150, ErrorMessage = "MinAge should be between 0 and 150.")]
        public int MinAge { get; set; }

        [Required]
        [Range(0, 150, ErrorMessage = "MaxAge should be between 0 and 150.")]
        public int MaxAge { get; set; }

        [Required]
        [Range(0, 200, ErrorMessage = "MaxWeight should be between 0 and 200.")]
        public int MaxWeight { get; set; }

        [Required]
        public BeltNames Belt { get; set; }

        [Required]
        [Range(0, 15)]
        public int FightTimeMinutes { get; set; }

        public ICollection<ChampionshipCategory> ChampionshipCategories { get; set; }
            = new List<ChampionshipCategory>();

       
        public Category(string name, int minAge, int maxAge, int maxWeight, int fightTimeMinutes, BeltNames belt = BeltNames.White)
        {
            Name = name;
            MinAge = minAge;
            MaxAge = maxAge;
            MaxWeight = maxWeight;
            FightTimeMinutes = fightTimeMinutes;
            Belt = belt;
        }
    }
}
