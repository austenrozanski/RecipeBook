using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Business.SavedRecipes.Delete;

public class DeleteSavedRecipeCommandHandler : IRequestHandler<DeleteSavedRecipeCommand>
{
    private readonly ISavedRecipeRepository _savedRecipeRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public DeleteSavedRecipeCommandHandler(
        ISavedRecipeRepository savedRecipeRepository,
        IUnitOfWork unitOfWork)
    {
        _savedRecipeRepository = savedRecipeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteSavedRecipeCommand request, CancellationToken cancellationToken)
    {
        var savedRecipe = await _savedRecipeRepository.GetSavedRecipeForUserAsync(request.UserId, request.RecipeId);

        if (savedRecipe == null)
        {
            throw new SavedRecipeNotFoundException(request.RecipeId);
        }
        _savedRecipeRepository.Remove(savedRecipe);
        _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}