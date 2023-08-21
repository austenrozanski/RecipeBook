using Application.Business.Recipes.Models;
using MediatR;

namespace Application.Business.Recipes.Create;

public class CreateRecipeCommand : IRequest
{
    public RecipeRequest Recipe { get; set; }
}