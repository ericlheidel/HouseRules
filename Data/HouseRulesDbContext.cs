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

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
        {
            new IdentityUser
            {
                Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                UserName = "Charlie",
                Email = "charlie@kelly.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "frt98wr5-0223-3ww7-t6rq-028g4r521d4e",
                UserName = "Frank",
                Email = "frank@reynolds.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "hdp65oa9-3053-5ap0-z0hh-235t2a098h8q",
                UserName = "Mac",
                Email = "mac@mcdonald.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },

        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile
            {
                Id = 1,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                FirstName = "Charlie",
                LastName = "Kelly",
                Address = "101 Main Street",
                UserName = "Charlie",
                Email = "charlie@kelly.com"
            },
            new UserProfile
            {
                Id = 2,
                IdentityUserId = "frt98wr5-0223-3ww7-t6rq-028g4r521d4e",
                FirstName = "Frank",
                LastName = "Reynolds",
                Address = "222 Broadway Ave.",
                UserName = "Frank",
                Email = "frank@reynolds.com"
            },
            new UserProfile
            {
                Id = 3,
                IdentityUserId = "hdp65oa9-3053-5ap0-z0hh-235t2a098h8q",
                FirstName = "Mac",
                LastName = "McDonald",
                Address = "333 Broadway Ave.",
                UserName = "Mac",
                Email = "mac@mcdonald.com"
            },
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
                ChoreFrequencyDays = 12
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
                ChoreFrequencyDays = 14
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
            },
            new ChoreAssignment
            {
                Id = 3,
                UserProfileId = 1,
                ChoreId = 3
            },
            new ChoreAssignment
            {
                Id = 4,
                UserProfileId = 1,
                ChoreId = 4
            },
            new ChoreAssignment
            {
                Id = 5,
                UserProfileId = 1,
                ChoreId = 5
            },
            new ChoreAssignment
            {
                Id = 6,
                UserProfileId = 1,
                ChoreId = 6
            },
            new ChoreAssignment
            {
                Id = 7,
                UserProfileId = 1,
                ChoreId = 7
            },
            new ChoreAssignment
            {
                Id = 8,
                UserProfileId = 1,
                ChoreId = 8
            },
            new ChoreAssignment
            {
                Id = 9,
                UserProfileId = 1,
                ChoreId = 9
            },
            new ChoreAssignment
            {
                Id = 10,
                UserProfileId = 1,
                ChoreId = 10
            },
            new ChoreAssignment
            {
                Id = 11,
                UserProfileId = 1,
                ChoreId = 11
            },
            new ChoreAssignment
            {
                Id = 12,
                UserProfileId = 1,
                ChoreId = 12
            },
        });

        modelBuilder.Entity<ChoreCompletion>().HasData(new ChoreCompletion[]
        {
            new ChoreCompletion
            {
                Id = 1,
                UserProfileId = 1,
                ChoreId = 1,
                CompletedOn = DateTime.Now.AddDays(-1)
            },
            new ChoreCompletion
            {
                Id = 2,
                UserProfileId = 1,
                ChoreId = 2,
                CompletedOn = DateTime.Now.AddDays(-2)
            },
            new ChoreCompletion
            {
                Id = 3,
                UserProfileId = 1,
                ChoreId = 3,
                CompletedOn = DateTime.Now.AddDays(-3)
            },
            new ChoreCompletion
            {
                Id = 4,
                UserProfileId = 1,
                ChoreId = 4,
                CompletedOn = DateTime.Now.AddDays(-4)
            },
            new ChoreCompletion
            {
                Id = 5,
                UserProfileId = 1,
                ChoreId = 5,
                CompletedOn = DateTime.Now.AddDays(-5)
            },
            new ChoreCompletion
            {
                Id = 6,
                UserProfileId = 1,
                ChoreId = 6,
                CompletedOn = DateTime.Now.AddDays(-6)
            },
            new ChoreCompletion
            {
                Id = 7,
                UserProfileId = 1,
                ChoreId = 7,
                CompletedOn = DateTime.Now.AddDays(-7)
            },
            new ChoreCompletion
            {
                Id = 8,
                UserProfileId = 1,
                ChoreId = 8,
                CompletedOn = DateTime.Now.AddDays(-8)
            },
            new ChoreCompletion
            {
                Id = 9,
                UserProfileId = 1,
                ChoreId = 9,
                CompletedOn = DateTime.Now.AddDays(-9)
            },
            new ChoreCompletion
            {
                Id = 10,
                UserProfileId = 1,
                ChoreId = 10,
                CompletedOn = DateTime.Now.AddDays(-10)
            },
            new ChoreCompletion
            {
                Id = 11,
                UserProfileId = 1,
                ChoreId = 11,
                CompletedOn = DateTime.Now.AddDays(-11)
            },
            new ChoreCompletion
            {
                Id = 12,
                UserProfileId = 1,
                ChoreId = 12,
                CompletedOn = DateTime.Now.AddDays(-12)
            }
        });
    }
}