using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Business.Recipes.Delete;

public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRecipeCommandHandler(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
    {
        _recipeRepository = recipeRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = await _recipeRepository.GetByIdAsync(request.RecipeId);

        if (recipe == null)
        {
            throw new RecipeNotFoundException(request.RecipeId);
        }
        
        _recipeRepository.Remove(recipe);
        _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}