using Domain.Entities.SavedRecipe;
using Domain.Repositories;
using MediatR;

namespace Application.Business.SavedRecipes.Update;

public class UpdateSavedRecipeCommandHandler : IRequestHandler<UpdateSavedRecipeCommand>
{
    private readonly ISavedRecipeRepository _savedRecipeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSavedRecipeCommandHandler(
        ISavedRecipeRepository savedRecipeRepository,
        IUnitOfWork unitOfWork)
    {
        _savedRecipeRepository = savedRecipeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateSavedRecipeCommand request, CancellationToken cancellationToken)
    {
        var savedRecipe = await _savedRecipeRepository
            .GetSavedRecipeForUserAsync(request.UserId, request.RecipeId);

        if (savedRecipe == null)
        {
            savedRecipe = new SavedRecipe()
            {
                UserId = request.UserId,
                RecipeId = request.RecipeId,
                IsHearted = request.IsHearted
            };
            _savedRecipeRepository.Add(savedRecipe);
        }
        else
        {
            savedRecipe.IsHearted = request.IsHearted;
        }
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}