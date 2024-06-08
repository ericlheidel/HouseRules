using Microsoft.AspNetCore.Identity;
// using System.Text.Json.Serialization;

namespace HouseRules.Models.DTOs;

public class UserProfileDTO
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? Roles { get; set; }
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? IdentityUserId { get; set; }
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IdentityUser? IdentityUser { get; set; }
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ChoreAssignmentDTO>? ChoreAssignments { get; set; }
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ChoreCompletionDTO>? ChoreCompletions { get; set; }
}