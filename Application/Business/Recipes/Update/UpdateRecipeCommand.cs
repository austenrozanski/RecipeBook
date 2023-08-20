using Application.Business.Recipes.Models;
using MediatR;

namespace Application.Business.Recipes.Update;

public class UpdateRecipeCommand : IRequest
{
    public int RecipeId { get; set; }
    public RecipeDto Recipe { get; set; }
}