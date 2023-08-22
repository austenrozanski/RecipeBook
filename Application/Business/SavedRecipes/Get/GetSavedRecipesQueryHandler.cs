using Application.Business.Recipes.Models;
using Domain.Repositories;
using MediatR;

namespace Application.Business.SavedRecipes.Get;

public class GetSavedRecipesQueryHandler : IRequestHandler<GetSavedRecipesQuery, IEnumerable<RecipeSummaryResponse>>
{
    private readonly ISavedRecipeRepository _savedRecipeRepository;
    private readonly IRecipeRepository _recipeRepository;
    
    public GetSavedRecipesQueryHandler(
        ISavedRecipeRepository savedRecipeRepository,
        IRecipeRepository recipeRepository)
    {
        _savedRecipeRepository = savedRecipeRepository;
        _recipeRepository = recipeRepository;
    }

    public async Task<IEnumerable<RecipeSummaryResponse>> Handle(GetSavedRecipesQuery request, CancellationToken cancellationToken)
    {
        var savedRecipes = await _savedRecipeRepository.GetSavedRecipesForUserAsync(request.UserId);
        var savedRecipeIds = savedRecipes.Select(f => f.RecipeId).ToList();

        var recipes = await _recipeRepository.GetByIdsAsync(savedRecipeIds);
        var recipeSummaries = recipes.Select(f => new RecipeSummaryResponse(f));
        return recipeSummaries;
    }
}