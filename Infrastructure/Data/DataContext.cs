using Domain.Entities;
using Domain.Entities.Recipe;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<Recipe> Recipes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>(ConfigureRecipes);
    }

    private static void ConfigureRecipes(EntityTypeBuilder<Recipe> config)
    {
        config.OwnsOne(f => f.IngredientGroups,
            builder => builder.ToJson());
        
        config.OwnsOne(f => f.InstructionGroups,
            builder => builder.ToJson());
        
        config.OwnsOne(f => f.TipsAndTricksGroups,
            builder => builder.ToJson());
        
        config.OwnsOne(f => f.DescriptionGroups,
            builder => builder.ToJson());
    }
    
}