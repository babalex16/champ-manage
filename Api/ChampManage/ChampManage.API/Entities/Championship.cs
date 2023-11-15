﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChampManage.API.Entities
{
    public class Championship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Location { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime EventDateTime { get; set; }
        
        [Required]
        public decimal RegistrationFee{ get; set; }

        public DateTime RegistrationDeadline { get; set; }

        public string? Description { get; set; }

        [ForeignKey("OrganizerId")]
        public User Organizer { get; set; }
        public int OrganizerId { get; set; }
        
        public ICollection<User> Participants { get; set; }
            = new List<User>();

        public ICollection<ChampionshipCategory> ChampionshipCategories { get; set; }
            = new List<ChampionshipCategory>();
        public Championship(string title, string location, DateTime eventDateTime, decimal registrationFee, int organizerId)
        {
            Title = title;
            Location = location;
            EventDateTime = eventDateTime;
            RegistrationFee = registrationFee;
            OrganizerId = organizerId;
        }
    }
}
