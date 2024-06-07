using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HouseRules.Data;
using HouseRules.Models.DTOs;
using Microsoft.EntityFrameworkCore.Update.Internal;
using HouseRules.Models;

namespace HouseRules.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private HouseRulesDbContext _dbContext;

    public UserProfileController(HouseRulesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
            .UserProfile
            .Include(up => up.IdentityUser)
            .Select(up => new UserProfileDTO
            {
                Id = up.Id,
                FirstName = up.FirstName,
                LastName = up.LastName,
                Address = up.Address,
                UserName = up.UserName,
                Email = up.Email,
                IdentityUserId = up.IdentityUser.Id
            })
            .ToList());
    }

    [HttpGet("withroles")]
    [Authorize]
    public IActionResult GetWithRoles()
    {
        return Ok(_dbContext.UserProfile
        .Include(up => up.IdentityUser)
        .Select(up => new UserProfileDTO
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Address = up.Address,
            Email = up.Email,
            UserName = up.UserName,
            IdentityUserId = up.IdentityUser.Id,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList()
        }));
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetProfileById(int id)
    {
        UserProfile userProfile = _dbContext
        .UserProfile
        .Include(up => up.ChoreAssignments)
            .ThenInclude(ca => ca.Chore)
        .Include(up => up.ChoreCompletions)
            .ThenInclude(cc => cc.Chore)
        .SingleOrDefault(up => up.Id == id);

        if (userProfile == null)
        {
            return NotFound();
        }

        return Ok(userProfile);
    }
}