using Domain.Repositories;
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
        // TODO: Use mapper
        var recipe = new Recipe()
        {
            Name = request.Recipe.Name,
            Servings = request.Recipe.Servings,
            ImageUrl = request.Recipe.ImageUrl,
            Author = request.Recipe.Author,
            SourceUrl = request.Recipe.SourceUrl,
            PrepTimeSeconds = request.Recipe.PrepTimeSeconds,
            CookTimeSeconds = request.Recipe.CookTimeSeconds,
            DescriptionGroups = request.Recipe.DescriptionGroups,
            IngredientGroups = request.Recipe.IngredientGroups,
            InstructionGroups = request.Recipe.InstructionGroups,
            TipsAndTricksGroups = request.Recipe.TipsAndTricksGroups
        };
        
        _recipeRepository.Add(recipe);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}