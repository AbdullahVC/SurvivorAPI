using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurvivorAPI.Data;
using SurvivorAPI.DTOs;
using SurvivorAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
    {
        var categories = await _context.Categories
            .Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();

        return Ok(categories);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> PostCategory(CategoryDTO categoryDTO)
    {
        var category = new Category
        {
            Name = categoryDTO.Name
        };

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCategories), new { id = category.Id }, categoryDTO);
    }
}
