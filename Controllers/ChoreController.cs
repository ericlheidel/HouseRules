using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HouseRules.Data;
using HouseRules.Models;
using HouseRules.Models.DTOs;
// using HouseRules.Migrations;

namespace HouseRules.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChoreController : ControllerBase
{
    private HouseRulesDbContext _dbContext;

    public ChoreController(HouseRulesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
        .Chore
        .Select(c => new ChoreDTO
        {
            Id = c.Id,
            Name = c.Name,
            Difficulty = c.Difficulty,
            ChoreFrequencyDays = c.ChoreFrequencyDays,
            ChoreAssignments = c.ChoreAssignments.Select(ca => new ChoreAssignmentDTO
            {
                Id = ca.Id,
                UserProfileId = ca.UserProfileId

            }).ToList(),

            ChoreCompletions = c.ChoreCompletions.Select(cc => new ChoreCompletionDTO
            {
                Id = cc.Id,
                UserProfileId = cc.UserProfileId,
                ChoreId = cc.ChoreId,
                CompletedOn = cc.CompletedOn
            }).ToList()
        })
        .ToList());
    }

    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetChoreById(int id)
    {
        Chore chore = _dbContext
        .Chore
        .Include(c => c.ChoreAssignments)
            .ThenInclude(ca => ca.UserProfile)
        .Include(c => c.ChoreCompletions)
        .SingleOrDefault(c => c.Id == id);

        if (chore == null)
        {
            return NotFound();
        }

        return Ok(new ChoreDTO
        {
            Id = chore.Id,
            Name = chore.Name,
            Difficulty = chore.Difficulty,
            ChoreFrequencyDays = chore.ChoreFrequencyDays,
            ChoreAssignments = chore.ChoreAssignments
            .Select(ca => new ChoreAssignmentDTO
            {
                Id = ca.Chore.Id,
                UserProfileId = ca.UserProfileId,
                UserProfile = new UserProfileDTO
                {
                    Id = ca.UserProfile.Id,
                    FirstName = ca.UserProfile.FirstName,
                    LastName = ca.UserProfile.LastName,
                    Address = ca.UserProfile.Address,
                    UserName = ca.UserProfile.UserName,
                    Email = ca.UserProfile.Email
                },
                ChoreId = ca.ChoreId
            }).ToList(),
            ChoreCompletions = chore.ChoreCompletions
            .Select(cc => new ChoreCompletionDTO
            {
                Id = cc.Id,
                UserProfileId = cc.UserProfileId,
                ChoreId = cc.ChoreId,
                CompletedOn = cc.CompletedOn
            }).ToList()
        });
    }

    //POST /api/chore/{id}/complete
    //This endpoint will create a new ChoreCompletion.
    //Use a query string parameter to indicate the userId that will be assigned 
    //to the chore matching the id in the URL.
    //Set the CompletedOn property in the controller method so that the client doesn't have to pass it in.
    //This endpoint can return a 204 No Content response once it has created the completion.

    [HttpPost("{id}/complete")]
    // "/api/chore/{id}/complete?userId={userId}
    // [Authorize]
    public IActionResult CompleteChore(int id, [FromQuery] int userId)
    {
        // find the chore by Id
        Chore chore = _dbContext.Chore.SingleOrDefault(c => c.Id == id);

        if (chore == null)
        {
            return NotFound();
        }

        // find the user by Id
        UserProfile user = _dbContext.UserProfile.SingleOrDefault(up => up.Id == userId);

        if (user == null)
        {
            return NotFound();
        }

        // create new ChoreCompletion instance
        ChoreCompletion newChoreCompletion = new ChoreCompletion
        {
            UserProfileId = userId,
            ChoreId = id,
            CompletedOn = DateTime.Now
        };

        _dbContext.ChoreCompletion.Add(newChoreCompletion);
        _dbContext.SaveChanges();

        return NoContent();

    }

    [HttpPost]
    // [Authorize]
    public IActionResult CreateChore(Chore chore)
    {
        Chore newChore = new Chore
        {
            Name = chore.Name,
            Difficulty = chore.Difficulty,
            ChoreFrequencyDays = chore.ChoreFrequencyDays
        };

        _dbContext.Chore.Add(newChore);
        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPut("{id}")]
    // [Authorize]
    public IActionResult UpdateChore(Chore chore, int id)
    {
        Chore choreToUpdate = _dbContext.Chore.SingleOrDefault(c => c.Id == id);

        if (choreToUpdate == null)
        {
            return NotFound();
        }

        choreToUpdate.Name = chore.Name;
        choreToUpdate.Difficulty = chore.Difficulty;
        choreToUpdate.ChoreFrequencyDays = chore.ChoreFrequencyDays;

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    // [Authorize]
    public IActionResult DeleteChore(int id)
    {
        Chore choreToDelete = _dbContext.Chore.SingleOrDefault(c => c.Id == id);

        if (choreToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Remove(choreToDelete);
        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPost("{id}/assign")]
    // "/api/chore/{id}?userId={userId}
    // [Authorize]
    public IActionResult AssignChore(int id, [FromQuery] int userId)
    {
        // This endpoint will assign a chore to a user.
        // Pass the userId in as a query string param, as in the completion endpoint above.
        // This endpoint can return a 204 response.

        ChoreAssignment newChoreAssignment = new ChoreAssignment
        {
            UserProfileId = userId,
            ChoreId = id
        };

        _dbContext.ChoreAssignment.Add(newChoreAssignment);
        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPost("{id}/unassign")]
    // "/api/chore/{id}/unassign?userId={userId}
    // [Authorize]
    public IActionResult UnassignChore(int id, [FromQuery] int userId)
    {
        // This endpoint will unassign a chore to a user.
        // Pass the userId in as a query string param, as in the other endpoints above.

        ChoreAssignment choreAssignmentToDelete =
        _dbContext.ChoreAssignment.SingleOrDefault(
            ca => ca.UserProfileId == userId && ca.ChoreId == id);

        if (choreAssignmentToDelete == null)
        {
            return NotFound();
        }

        _dbContext.ChoreAssignment.Remove(choreAssignmentToDelete);
        _dbContext.SaveChanges();

        return NoContent();
    }

}