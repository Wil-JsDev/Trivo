using Microsoft.EntityFrameworkCore;
using Trivo.Application.Interfaces.UnitOfWork;

namespace Trivo.Infrastructure.Persistence.Context;

public class TrivoContext(DbContextOptions<TrivoContext> options) : DbContext(options), IUnitOfWork
{
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        
        return result;
    }
}