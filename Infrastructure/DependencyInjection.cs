using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient(typeof(IActivityRepository), typeof(ActivityRepository));
        services.AddTransient(typeof(IAppUserRepository), typeof(AppUserRepository));
        services.AddTransient(typeof(IFriendRepository), typeof(FriendRepository));
        services.AddTransient(typeof(IRecipeRepository), typeof(RecipeRepository));
        services.AddTransient(typeof(ISavedRecipeRepository), typeof(SavedRecipeRepository));
        services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
        return services;
    }
}