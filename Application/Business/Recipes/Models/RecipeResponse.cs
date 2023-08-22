using Domain.Entities.Recipe;

namespace Application.Business.Recipes.Models;

public class RecipeResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Servings { get; set; }
    public string ImageUrl { get; set; }
    public string Author { get; set; }
    public string SourceUrl { get; set; }
    public int PrepTimeSeconds { get; set; }
    public int CookTimeSeconds { get; set; }
    public int TotalTimeSeconds { get; set; }
    public bool IsSaved { get; set; }
    public bool IsHearted { get; set; }
    
    public List<RecipeDescriptionGroup> DescriptionGroups { get; set; }
    public List<RecipeIngredientGroup> IngredientGroups { get; set; }
    public List<RecipeInstructionGroup> InstructionGroups { get; set; }
    public List<RecipeTipsAndTricksGroup> TipsAndTricksGroups { get; set; }

    public RecipeResponse() { }
    
    // TODO: Use mapper
    public RecipeResponse(Recipe recipe)
    {
        Id = recipe.Id;
        Name = recipe.Name;
        Servings = recipe.Servings;
        ImageUrl = recipe.ImageUrl;
        Author = recipe.Author;
        SourceUrl = recipe.SourceUrl;
        PrepTimeSeconds = recipe.PrepTimeSeconds;
        CookTimeSeconds = recipe.CookTimeSeconds;
        TotalTimeSeconds = recipe.GetTotalTimeSeconds();
        DescriptionGroups = recipe.DescriptionGroups;
        IngredientGroups = recipe.IngredientGroups;
        InstructionGroups = recipe.InstructionGroups;
        TipsAndTricksGroups = recipe.TipsAndTricksGroups;
    }
}