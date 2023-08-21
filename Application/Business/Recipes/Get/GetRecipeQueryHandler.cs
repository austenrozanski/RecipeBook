using Application.Business.Recipes.Models;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Business.Recipes.Get;

public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, RecipeResponse>
{
    private readonly IRecipeRepository _recipeRepository;

    public GetRecipeQueryHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    
    public async Task<RecipeResponse> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
    {
        var recipe = await _recipeRepository.GetByIdAsync(request.RecipeId);

        if (recipe == null)
        {
            throw new RecipeNotFoundException(request.RecipeId);
        }
        
        var response = new RecipeResponse(recipe);
        return response;
    }
}