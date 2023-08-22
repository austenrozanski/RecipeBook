using Application.Business.Recipes.Models;
using MediatR;

namespace Application.Business.SavedRecipes.Get;

public class GetSavedRecipesQuery : IRequest<IEnumerable<RecipeSummaryResponse>>
{
    public long UserId { get; set; }
}