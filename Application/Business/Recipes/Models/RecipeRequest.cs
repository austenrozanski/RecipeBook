using Domain.Entities.Recipe;

namespace Application.Business.Recipes.Models;

public class RecipeRequest
{
    public string Name { get; set; }
    public int Servings { get; set; }
    public string ImageUrl { get; set; }
    public string Author { get; set; }
    public string SourceUrl { get; set; }
    public int PrepTimeSeconds { get; set; }
    public int CookTimeSeconds { get; set; }
    
    public List<RecipeDescriptionGroup> DescriptionGroups { get; set; }
    public List<RecipeIngredientGroup> IngredientGroups { get; set; }
    public List<RecipeInstructionGroup> InstructionGroups { get; set; }
    public List<RecipeTipsAndTricksGroup> TipsAndTricksGroups { get; set; }

    // TODO: Use mapper
    public Recipe ToRecipeEntity()
    {
        Recipe recipe = new Recipe()
        {
            Name = this.Name,
            Servings = this.Servings,
            ImageUrl = this.ImageUrl,
            Author = this.Author,
            SourceUrl = this.SourceUrl,
            PrepTimeSeconds = this.PrepTimeSeconds,
            CookTimeSeconds = this.CookTimeSeconds,
            DescriptionGroups = this.DescriptionGroups,
            IngredientGroups = this.IngredientGroups,
            InstructionGroups = this.InstructionGroups,
            TipsAndTricksGroups = this.TipsAndTricksGroups
        };
        return recipe;
    }
}