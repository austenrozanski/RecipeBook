using Domain.Entities.Recipe;

namespace Application.Business.Recipes.Models;

public class RecipeSummaryResponse
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
    
    public RecipeSummaryResponse() { }
    // TODO: Use mapper
    public RecipeSummaryResponse(Recipe recipe)
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
    }
}