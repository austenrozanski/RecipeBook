using Application.Business.Recipes.Models;
using MediatR;

namespace Application.Business.Recipes.Get;

public class GetRecipeQuery : IRequest<RecipeResponse>
{
    public long RecipeId { get; set; }
    public long UserId { get; set; }
}