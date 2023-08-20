using Application.Business.Recipes.Models;
using MediatR;

namespace Application.Business.Recipes.Get;

public class GetRecipeQuery : IRequest<RecipeDto>
{
    public int RecipeId { get; set; }
}