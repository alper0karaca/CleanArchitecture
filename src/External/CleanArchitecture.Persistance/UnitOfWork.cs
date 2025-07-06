using CleanArchitecture.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance;

public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
    private readonly TContext _context;
    
    public UnitOfWork(TContext context)
    {
        _context = context;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}