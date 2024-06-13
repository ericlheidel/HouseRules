using System.ComponentModel.DataAnnotations;

namespace HouseRules.Models;

public class Chore
{
    public int Id { get; set; }
    [MinLength(1, ErrorMessage = "Please enter a chore name.")]
    [MaxLength(100, ErrorMessage = "Chore names must be 100 characters or less.")]
    public string? Name { get; set; }
    [Range(1, 5, ErrorMessage = "Chore difficulty must be between 1 & 5.")]
    public int Difficulty { get; set; }
    [Range(1, 14, ErrorMessage = "Frequency must be between 1 and 14 days.")]
    public int ChoreFrequencyDays { get; set; }
    public List<ChoreCompletion>? ChoreCompletions { get; set; }
    public List<ChoreAssignment>? ChoreAssignments { get; set; }
    public bool Overdue
    {
        get
        {
            if (ChoreCompletions == null || !ChoreCompletions.Any())
            {
                return false;
            }

            DateTime mostRecentCompletionDate = ChoreCompletions.Max(cc => cc.CompletedOn);

            DateTime nextDueDate = mostRecentCompletionDate.AddDays(ChoreFrequencyDays).Date;

            return nextDueDate < DateTime.Today;
        }
    }
}