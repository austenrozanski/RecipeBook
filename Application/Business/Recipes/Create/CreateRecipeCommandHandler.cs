using Domain.Interfaces.Repositories;
using MediatR;
using Domain.Entities.Recipe;

namespace Application.Business.Recipes.Create;

public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRecipeCommandHandler(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
    {
        _recipeRepository = recipeRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = request.Recipe.ToRecipeEntity();
        _recipeRepository.Add(recipe);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}