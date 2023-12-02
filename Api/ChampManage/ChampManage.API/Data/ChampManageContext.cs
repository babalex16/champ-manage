using ChampManage.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ChampManage.API.Data
{
    public class ChampManageContext : DbContext
    {
        public ChampManageContext(DbContextOptions<ChampManageContext> options)
            : base(options)
        {

        }
        public DbSet<BracketNode> Matches { get; set; }
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Championship> Championships { get; set; } = null!;
        public DbSet<ChampionshipCategory> ChampionshipCategories { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserCategoryRegistration> UserCategoryRegistrations { get; set; } = null!;
        public DbSet<News> News { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Championship>()
                .HasOne(c => c.Organizer)
                .WithMany(u => u.CreatedChampionships)
                .HasForeignKey(c => c.OrganizerId);

            modelBuilder.Entity<BracketNode>()
                .HasOne(b => b.LeftChild)
                .WithOne()
                .HasForeignKey<BracketNode>(b => b.LeftChildId);

            modelBuilder.Entity<BracketNode>()
                .HasOne(b => b.RightChild)
                .WithOne()
                .HasForeignKey<BracketNode>(b => b.RightChildId);

            //seeding categories
            modelBuilder.Entity<Category>().HasData(
                new Category("Pee Wee 1", 4, 5, 21, 2) { Id = 1 },
                new Category("Pee Wee 1", 4, 5, 200, 2) { Id = 2 },
                new Category("Pee Wee 2", 6, 7, 21, 3) { Id = 3 },
                new Category("Pee Wee 2", 6, 7, 24, 3) { Id = 4 },
                new Category("Pee Wee 2", 6, 7, 27, 3) { Id = 5 },
                new Category("Pee Wee 2", 6, 7, 30, 3) { Id = 6 },
                new Category("Pee Wee 2", 6, 7, 200, 3) { Id = 7 },
                new Category("Junior 1", 8, 9, 24, 3) { Id = 8 },
                new Category("Junior 1", 8, 9, 27, 3) { Id = 9 },
                new Category("Junior 1", 8, 9, 30, 3) { Id = 10 },
                new Category("Junior 1", 8, 9, 34, 3) { Id = 11 },
                new Category("Junior 1", 8, 9, 38, 3) { Id = 12 },
                new Category("Junior 1", 8, 9, 42, 3) { Id = 13 },
                new Category("Junior 1", 8, 9, 200, 3) { Id = 14 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
