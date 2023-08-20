using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Business.Recipes.Update;

public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRecipeCommandHandler(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
    {
        _recipeRepository = recipeRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = await _recipeRepository.GetByIdAsync(request.RecipeId);

        if (recipe == null)
        {
            throw new RecipeNotFoundException(request.RecipeId);
        }
        
        // TODO: Use mapper
        recipe.Name = request.Recipe.Name;
        recipe.Servings = request.Recipe.Servings;
        recipe.ImageUrl = request.Recipe.ImageUrl;
        recipe.Author = request.Recipe.Author;
        recipe.SourceUrl = request.Recipe.SourceUrl;
        recipe.PrepTimeSeconds = request.Recipe.PrepTimeSeconds;
        recipe.CookTimeSeconds = request.Recipe.CookTimeSeconds;
        recipe.DescriptionGroups = request.Recipe.DescriptionGroups;
        recipe.IngredientGroups = request.Recipe.IngredientGroups;
        recipe.InstructionGroups = request.Recipe.InstructionGroups;
        recipe.TipsAndTricksGroups = request.Recipe.TipsAndTricksGroups;

        _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}