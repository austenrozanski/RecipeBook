using MediatR;

namespace Application.Business.Recipes.Delete;

public class DeleteRecipeCommand : IRequest
{
    public int RecipeId { get; set; }
}