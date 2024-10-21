using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurvivorAPI.Data;
using SurvivorAPI.DTOs;
using SurvivorAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class CompetitorController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CompetitorController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompetitorDTO>>> GetCompetitors()
    {
        var competitors = await _context.Competitors
            .Select(c => new CompetitorDTO
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                CategoryId = c.CategoryId
            }).ToListAsync();

        return Ok(competitors);
    }

    [HttpPost]
    public async Task<ActionResult<CompetitorDTO>> PostCompetitor(CompetitorDTO competitorDTO)
    {
        var competitor = new Competitor
        {
            FirstName = competitorDTO.FirstName,
            LastName = competitorDTO.LastName,
            CategoryId = competitorDTO.CategoryId
        };

        _context.Competitors.Add(competitor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCompetitors), new { id = competitor.Id }, competitorDTO);
    }
}
