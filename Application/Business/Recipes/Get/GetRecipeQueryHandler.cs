using Application.Business.Recipes.Models;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Business.Recipes.Get;

public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, RecipeDto>
{
    private readonly IRecipeRepository _recipeRepository;

    public GetRecipeQueryHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    
    public async Task<RecipeDto> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
    {
        var recipe = await _recipeRepository.GetByIdAsync(request.RecipeId);

        if (recipe == null)
        {
            throw new RecipeNotFoundException(request.RecipeId);
        }
        
        // TODO: Use mapper
        var response = new RecipeDto()
        {
            Name = recipe.Name,
            Servings = recipe.Servings,
            ImageUrl = recipe.ImageUrl,
            Author = recipe.Author,
            SourceUrl = recipe.SourceUrl,
            PrepTimeSeconds = recipe.PrepTimeSeconds,
            CookTimeSeconds = recipe.CookTimeSeconds,
            DescriptionGroups = recipe.DescriptionGroups,
            IngredientGroups = recipe.IngredientGroups,
            InstructionGroups = recipe.InstructionGroups,
            TipsAndTricksGroups = recipe.TipsAndTricksGroups
        };

        return response;
    }
}