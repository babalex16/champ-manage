using ChampManage.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChampManage.API.Data
{
    public class ChampManageContext : DbContext
    {
        public ChampManageContext(DbContextOptions<ChampManageContext> options)
            : base(options)
        {

        }
        public DbSet<Championship> Championships { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Match> Matches { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Championship>()
                .HasOne(c => c.Organizer)
                .WithMany(u => u.CreatedChampionships)
                .HasForeignKey(c => c.OrganizerId);
            
            // Defining a list of matches for each championship
            var championship1Matches = new List<Match>
{
                new Match
                {
                    Id = 1,
                    Participant1Id = 1,
                    Participant2Id = 2,
                    WinnerId = 1,
                },
            };

            var championship2Matches = new List<Match>
            {
                new Match
                {
                    Id = 2,
                    Participant1Id = 3,
                    Participant2Id = 4,
                    WinnerId = 3,
                },
            };

            var championship3Matches = new List<Match>
            {
                new Match
                {
                    Id = 3,
                    Participant1Id = 5,
                    Participant2Id = 6,
                    WinnerId = 5,
                },
            };

            // Seeding Championships
            modelBuilder.Entity<Championship>().HasData(
                new Championship("Championship 1", "Location 1", new DateTime(2023, 1, 15), 50.00m)
                {
                    Id = 1,
                    RegistrationDeadline = new DateTime(2023, 1, 15),
                    Description = "Description of Championship 1",
                    OrganizerId = 1,
                    Matches = championship1Matches,
                },
                new Championship("Championship 2", "Location 2", new DateTime(2023, 2, 20), 40.00m)
                {
                    Id = 2,
                    RegistrationDeadline = new DateTime(2023, 2, 20),
                    Description = "Description of Championship 2",
                    OrganizerId = 2,
                    Matches = championship2Matches,
                },
                new Championship("Championship 3", "Location 3", new DateTime(2023, 3, 25), 60.00m)
                {
                    Id = 3,
                    RegistrationDeadline = new DateTime(2023, 3, 25),
                    Description = "Description of Championship 3",
                    OrganizerId = 3,
                    Matches = championship3Matches,
                }
            );

            // Seeding Users
            modelBuilder.Entity<User>().HasData(
               new User("John", "Doe", "john@example.com")
               {
                   Id = 1,
                   Gender = Gender.Male,
                   Birthdate = new DateTime(1990, 5, 15),
                   TeamName = "Team A",
                   Weight = 80,
                   Belt = BeltNames.White,
                   UserType = UserType.Organizer,
                   Phone = "123-456-7890"
               },
                new User("Jane", "Smith", "jane@example.com")
                {
                    Id = 2,
                    Gender = Gender.Female,
                    Birthdate = new DateTime(1995, 8, 20),
                    TeamName = "Team B",
                    Weight = 50,
                    Belt = BeltNames.Blue,
                    UserType = UserType.Organizer,
                    Phone = "987-654-3210"
                },
                new User("Bob", "Johnson", "bob@example.com")
                {
                    Id = 3,
                    Gender = Gender.Male,
                    Birthdate = new DateTime(1985, 3, 10),
                    TeamName = "Team C",
                    Weight = 99,
                    Belt = BeltNames.Purple,
                    UserType = UserType.Participant,
                    Phone = "555-123-4567"
                },
                new User("Alice", "Johnson", "alice@example.com")
                {
                    Id = 4,
                    Gender = Gender.Female,
                    Birthdate = new DateTime(1998, 7, 18),
                    TeamName = "Team D",
                    Weight = 55,
                    Belt = BeltNames.Blue,
                    UserType = UserType.Participant,
                    Phone = "789-012-3456"
                },
                new User("Michael", "Smith", "michael@example.com")
                {
                    Id = 5,
                    Gender = Gender.Male,
                    Birthdate = new DateTime(1992, 9, 25),
                    TeamName = "Team E",
                    Weight = 78,
                    Belt = BeltNames.Purple,
                    UserType = UserType.Participant,
                },
                new User("Samantha", "Brown", "samantha@example.com")
                {
                    Id = 6,
                    Gender = Gender.Female,
                    Birthdate = new DateTime(1989, 12, 3),
                    TeamName = "Team F",
                    Weight = 68,
                    Belt = BeltNames.White,
                    UserType = UserType.Participant,
                }
            ); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
