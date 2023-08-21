using MediatR;

namespace Application.Business.Recipes.Delete;

public class DeleteRecipeCommand : IRequest
{
    public long RecipeId { get; set; }
}