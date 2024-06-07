using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HouseRules.Models;
using Microsoft.AspNetCore.Identity;

namespace HouseRules.Data;
public class HouseRulesDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<Chore> Chore { get; set; }
    public DbSet<ChoreAssignment> ChoreAssignment { get; set; }
    public DbSet<ChoreCompletion> ChoreCompletion { get; set; }
    public DbSet<UserProfile> UserProfile { get; set; }

    public HouseRulesDbContext(DbContextOptions<HouseRulesDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole[]
        {
            new IdentityRole
            {
                Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                Name = "Admin",
                NormalizedName = "admin"
            }
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Adminastrator",
            Email = "charlie@kelly.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Charlie",
            LastName = "Kelly",
            Address = "101 Main Street",
            UserName = "Charlie",
            Email = "charlie@kelly.com"
        });

        modelBuilder.Entity<Chore>().HasData(new Chore[]
        {
            new Chore
            {
                Id = 1,
                Name = "Wash Dishes",
                Difficulty = 1,
                ChoreFrequencyDays = 1
            },
            new Chore
            {
                Id = 2,
                Name = "Vacuum Living Room",
                Difficulty = 2,
                ChoreFrequencyDays = 7
            },
            new Chore
            {
                Id = 3,
                Name = "Take Out Trash",
                Difficulty = 1,
                ChoreFrequencyDays = 2
            },
            new Chore
            {
                Id = 4,
                Name = "Clean Bathroom",
                Difficulty = 3,
                ChoreFrequencyDays = 14
            },
            new Chore
            {
                Id = 5,
                Name = "Mow Lawn",
                Difficulty = 4,
                ChoreFrequencyDays = 7
            },
            new Chore
            {
                Id = 6,
                Name = "Do Laundry",
                Difficulty = 2,
                ChoreFrequencyDays = 3
            },
            new Chore
            {
                Id = 7,
                Name = "Cook Dinner",
                Difficulty = 2,
                ChoreFrequencyDays = 1
            },
            new Chore
            {
                Id = 8,
                Name = "Clean Windows",
                Difficulty = 5,
                ChoreFrequencyDays = 30
            },
            new Chore
            {
                Id = 9,
                Name = "Dust Furniture",
                Difficulty = 1,
                ChoreFrequencyDays = 7
            },
            new Chore
            {
                Id = 10,
                Name = "Sweep Garage",
                Difficulty = 2,
                ChoreFrequencyDays = 14
            },
            new Chore
            {
                Id = 11,
                Name = "Water Plants",
                Difficulty = 1,
                ChoreFrequencyDays = 3
            },
            new Chore
            {
                Id = 12,
                Name = "Organize Pantry",
                Difficulty = 5,
                ChoreFrequencyDays = 60
            }
        });

        modelBuilder.Entity<ChoreAssignment>().HasData(new ChoreAssignment[]
        {
            new ChoreAssignment
            {
                Id = 1,
                UserProfileId = 1,
                ChoreId = 1
            },
            new ChoreAssignment
            {
                Id = 2,
                UserProfileId = 1,
                ChoreId = 2
            }
        });

        modelBuilder.Entity<ChoreCompletion>().HasData(new ChoreCompletion[]
        {
            new ChoreCompletion
            {
                Id = 1,
                UserProfileId = 1,
                ChoreId = 1,
                CompletedOn = DateTime.Now.AddDays(-1)
            }
        });
    }
}