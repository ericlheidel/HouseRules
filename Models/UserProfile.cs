
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HouseRules.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    [MaxLength(50, ErrorMessage = "Username must be 50 characters of less.")]
    public string? UserName { get; set; }
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string? Email { get; set; }
    public string? IdentityUserId { get; set; }
    public IdentityUser? IdentityUser { get; set; }
    public List<ChoreAssignment>? ChoreAssignments { get; set; }
    public List<ChoreCompletion>? ChoreCompletions { get; set; }
}