using API.Data;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _dataContext;

    public UnitOfWork(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dataContext.SaveChangesAsync(cancellationToken);
    }
}