using System.ComponentModel.DataAnnotations;

namespace HouseRules.Models.DTOs;

public class ChoreDTO
{
    public int Id { get; set; }
    [MinLength(1, ErrorMessage = "Please enter a chore name.")]
    [MaxLength(100, ErrorMessage = "Chore names must be 100 characters or less.")]
    public string? Name { get; set; }
    [Range(1, 5, ErrorMessage = "Chore difficulty must be between 1 & 5.")]
    public int Difficulty { get; set; }
    [Range(1, 14, ErrorMessage = "Frequency must be between 1 and 14 days.")]
    public int ChoreFrequencyDays { get; set; }
    public List<ChoreCompletionDTO>? ChoreCompletions { get; set; }
    public List<ChoreAssignmentDTO>? ChoreAssignments { get; set; }
    public bool Overdue
    {
        get
        {
            if (ChoreCompletions == null || !ChoreCompletions.Any())
            {
                return false;
            }
            // when was the last day the chore was completed?
            DateTime mostRecentCompletionDate = ChoreCompletions.Max(cc => cc.CompletedOn);

            // when is the next day the chore is due to be completed?
            DateTime nextDueDate = mostRecentCompletionDate.AddDays(ChoreFrequencyDays).Date;

            // if the next due date is less than today, then the due date is in the past and therefore Overdue: true
            // if the next due date is greater than today, then the due date is in the future, and therefore Overdue: false
            return nextDueDate < DateTime.Today;
        }
    }
}