using Application.Business.Recipes.Models;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Business.Recipes.Get;

public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, RecipeResponse>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly ISavedRecipeRepository _savedRecipeRepository;

    public GetRecipeQueryHandler(
        IRecipeRepository recipeRepository,
        ISavedRecipeRepository savedRecipeRepository)
    {
        _recipeRepository = recipeRepository;
        _savedRecipeRepository = savedRecipeRepository;
    }
    
    public async Task<RecipeResponse> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
    {
        var recipe = await _recipeRepository.GetByIdAsync(request.RecipeId);

        if (recipe == null)
        {
            throw new RecipeNotFoundException(request.RecipeId);
        }
        
        var response = new RecipeResponse(recipe);

        var savedRecipe = await _savedRecipeRepository.GetSavedRecipeForUserAsync(request.UserId, request.RecipeId);
        response.IsSaved = (savedRecipe != null);
        response.IsHearted = savedRecipe?.IsHearted ?? false;
        
        return response;
    }
}