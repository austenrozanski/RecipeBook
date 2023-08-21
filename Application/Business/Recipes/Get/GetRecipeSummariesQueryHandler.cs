using Application.Business.Recipes.Models;
using Domain.Repositories;
using MediatR;

namespace Application.Business.Recipes.Get;

public class GetRecipeSummariesQueryHandler : IRequestHandler<GetRecipeSummariesQuery, List<RecipeSummaryResponse>>
{
    private readonly IRecipeRepository _recipeRepository;

    public GetRecipeSummariesQueryHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    
    public async Task<List<RecipeSummaryResponse>> Handle(GetRecipeSummariesQuery request, CancellationToken cancellationToken)
    {
        var recipes = await _recipeRepository.GetSummaries();

        var response = recipes
            .Select(recipe => new RecipeSummaryResponse(recipe))
            .ToList();

        return response;
    }
}