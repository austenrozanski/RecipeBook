using Application.Authentication.Login;
using Application.Authentication.Models;
using Application.Business.AppUsers.Create;
using Application.Business.AppUsers.Delete;
using Application.Business.AppUsers.Get;
using Application.Business.AppUsers.Models;
using Application.Business.AppUsers.Update;
using Application.Business.Recipes.Models;
using Application.Business.SavedRecipes.Delete;
using Application.Business.SavedRecipes.Get;
using Application.Business.SavedRecipes.Update;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ISender _sender;

    public UsersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetUser(long id)
    {
        try
        {
            var request = new GetUserQuery()
            {
                UserId = id
            };
            var response = await _sender.Send(request);
            return Ok(response);
        }
        catch (UserNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<string>> Login([FromBody] LoginRequest loginRequest)
    {
        try
        {
            var request = new LoginCommand()
            {
                UserName = loginRequest.UserName
            };
            var response = await _sender.Send(request);
            return Ok(response);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> AddUser([FromBody] UserRequest user)
    {
        var request = new CreateUserCommand()
        {
            User = user
        };
        await _sender.Send(request);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<UserResponse>> UpdateUser(long id, [FromBody] UserRequest user)
    {
        try
        {
            var request = new UpdateUserCommand()
            {
                UserId = id,
                User = user
            };
            await _sender.Send(request);
            return Ok();
        }
        catch (UserNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<UserResponse>> RemoveUser(long id)
    {
        try
        {
            var request = new DeleteUserCommand()
            {
                UserId = id
            };
            await _sender.Send(request);
            return Ok();
        }
        catch (UserNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpGet("{userId}/friends")]
    public async Task<ActionResult<IEnumerable<UserSummaryResponse>>> GetFriendsOfUser(long userId)
    {
        var request = new GetUsersFriendsQuery()
        {
            UserId = userId
        };
        var response = await _sender.Send(request);
        return Ok(response);
    }

    #region Saved Recipes
    [HttpGet("{userId}/saved-recipes")]
    public async Task<ActionResult<IEnumerable<RecipeSummaryResponse>>> GetSavedRecipes(long userId)
    {
        var request = new GetSavedRecipesQuery()
        {
            UserId = userId
        };

        var response = await _sender.Send(request);
        return Ok(response);
    }

    [HttpPost("{userId}/saved-recipe/{recipeId}")]
    public async Task<ActionResult> SaveRecipe(long userId, long recipeId, [FromQuery] bool isHearted)
    {
        var request = new UpdateSavedRecipeCommand()
        {
            UserId = userId,
            RecipeId = recipeId,
            IsHearted = isHearted
        };

        await _sender.Send(request);
        return Ok();
    }
    
    [HttpDelete("{userId}/saved-recipe/{recipeId}")]
    public async Task<ActionResult> UnSaveRecipe(long userId, long recipeId)
    {
        try
        {
            var request = new DeleteSavedRecipeCommand()
            {
                UserId = userId,
                RecipeId = recipeId
            };

            await _sender.Send(request);
            return Ok();
        }
        catch (SavedRecipeNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    #endregion
}