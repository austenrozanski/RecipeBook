using Application.Business.Recipes.Models;
using Domain.Repositories;
using MediatR;

namespace Application.Business.Recipes.Get;

public class GetRecipeSummariesQueryHandler : IRequestHandler<GetRecipeSummariesQuery, List<RecipeSummaryDto>>
{
    private readonly IRecipeRepository _recipeRepository;

    public GetRecipeSummariesQueryHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    
    public Task<List<RecipeSummaryDto>> Handle(GetRecipeSummariesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}