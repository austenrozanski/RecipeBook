using Application.Business.Recipes.Models;
using Domain.Interfaces.Repositories;
using MediatR;
using MediatR.NotificationPublishers;

namespace Application.Business.Recipes.Get;

public class GetRecipeSummariesQueryHandler : IRequestHandler<GetRecipeSummariesQuery, List<RecipeSummaryResponse>>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly ISavedRecipeRepository _savedRecipeRepository;

    public GetRecipeSummariesQueryHandler(
        IRecipeRepository recipeRepository, 
        ISavedRecipeRepository savedRecipeRepository)
    {
        _recipeRepository = recipeRepository;
        _savedRecipeRepository = savedRecipeRepository;
    }
    
    public async Task<List<RecipeSummaryResponse>> Handle(GetRecipeSummariesQuery request, CancellationToken cancellationToken)
    {
        var recipes = await _recipeRepository.GetSummariesAsync();

        var recipeSummaries = recipes
            .Select(recipe => new RecipeSummaryResponse(recipe))
            .ToList();
        
        var savedRecipes = await _savedRecipeRepository.GetSavedRecipesForUserAsync(request.UserId);
        
        foreach (var recipe in recipeSummaries)
        {
            var savedRecipe = savedRecipes.FirstOrDefault(f => f.RecipeId == recipe.Id);
            recipe.IsSaved = (savedRecipe != null);
            recipe.IsHearted = savedRecipe?.IsHearted ?? false;
        }

        return recipeSummaries;
    }
}