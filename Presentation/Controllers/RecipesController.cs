using Application.Business.Recipes.Create;
using Application.Business.Recipes.Delete;
using Application.Business.Recipes.Get;
using Application.Business.Recipes.Models;
using Application.Business.Recipes.Update;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly ISender _sender;

    public RecipesController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<RecipeSummaryDto>>> GetRecipes()
    {
        var request = new GetRecipeSummariesQuery();

        var response = await _sender.Send(request);
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<RecipeDto>> GetRecipe(int id)
    {
        try
        {
            var request = new GetRecipeQuery()
            {
                RecipeId = id
            };

            var response = await _sender.Send(request);
            return Ok(response);
        }
        catch (RecipeNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateRecipe([FromBody] RecipeDto recipe)
    {
        var request = new CreateRecipeCommand()
        {
            Recipe = recipe
        };

        await _sender.Send(request);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateRecipe(int id, [FromBody] RecipeDto recipe)
    {
        try
        {
            var request = new UpdateRecipeCommand()
            {
                RecipeId = id,
                Recipe = recipe
            };

            await _sender.Send(request);
            return Ok();
        }
        catch (RecipeNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRecipe(int id)
    {
        try
        {
            var request = new DeleteRecipeCommand()
            {
                RecipeId = id
            };

            await _sender.Send(request);
            return Ok();
        }
        catch (RecipeNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}