using API.Data;
using API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly DataContext _context;
    
    public RecipesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<RecipeSummaryDTO>>> GetRecipes()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RecipeDTO>> GetRecipe(int id)
    {
        var user = await _context.Recipes.FindAsync(id);
        return Ok(user);
    }
    
    [HttpPost]
    public async Task<ActionResult<RecipeDTO>> CreateRecipe([FromBody] RecipeDTO recipeRequest)
    {
        var user = await _context.Recipes.FindAsync();
        return Ok(user);
    }
}