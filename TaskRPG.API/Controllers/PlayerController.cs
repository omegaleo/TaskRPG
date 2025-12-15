using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskRPG.API.Data;
using TaskRPG.Core.Models;

namespace TaskRPG.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public PlayerController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet("{id}")]
    public ActionResult<PlayerData> GetPlayerData(string id)
    {
        var playerData = _dbContext.PlayerData
            .Include(p => p.EquippedItems)
            .FirstOrDefault(p => p.Id.ToString().Equals(id, StringComparison.OrdinalIgnoreCase));
        
        if (playerData == null)
        {
            return NotFound();
        }
        
        return Ok(playerData);
    }
}