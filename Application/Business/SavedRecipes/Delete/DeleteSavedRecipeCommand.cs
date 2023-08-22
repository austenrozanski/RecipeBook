using MediatR;

namespace Application.Business.SavedRecipes.Delete;

public class DeleteSavedRecipeCommand : IRequest
{
    public long UserId { get; set; }
    public long RecipeId { get; set; }
}