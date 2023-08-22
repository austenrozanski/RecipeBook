using MediatR;

namespace Application.Business.SavedRecipes.Update;

public class UpdateSavedRecipeCommand : IRequest
{
    public long UserId { get; set; }
    public long RecipeId { get; set; }
    public bool IsHearted { get; set; }
}