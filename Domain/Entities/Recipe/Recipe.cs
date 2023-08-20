namespace Domain.Entities.Recipe;

public class Recipe : EntityBase
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

    #region Methods
    public int GetTotalTimeSeconds()
    {
        return PrepTimeSeconds + CookTimeSeconds;
    }
    #endregion
}