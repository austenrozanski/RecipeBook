using Domain.Entities.Activity;
using Domain.Entities.AppUser;
using Domain.Entities.Friend;
using Domain.Entities.Recipe;
using Domain.Entities.SavedRecipe;
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
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Friend> Friends { get; set; }
    public DbSet<SavedRecipe> SavedRecipes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>(ConfigureRecipes);
    }

    private static void ConfigureRecipes(EntityTypeBuilder<Recipe> config)
    {
        config.OwnsMany(f => f.IngredientGroups, builder =>
        {
            builder.ToJson();
            builder.OwnsMany(f => f.Ingredients);
        });

        config.OwnsMany(f => f.InstructionGroups,
            builder => builder.ToJson());
        
        config.OwnsMany(f => f.InstructionGroups, builder =>
        {
            builder.ToJson();
            builder.OwnsMany(f => f.Instructions, builder =>
            {
                builder.OwnsMany(f => f.Timers);
            });
        });

        config.OwnsMany(f => f.TipsAndTricksGroups,
            builder => builder.ToJson());
        
        config.OwnsMany(f => f.DescriptionGroups,
            builder => builder.ToJson());
    }
    
}