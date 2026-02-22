using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Trivo.Domain.Common;
using Trivo.Infrastructure.Persistence.Context;

namespace Trivo.Infrastructure.Persistence.Base;

public class Validation<TEntity>(TrivoContext context) : IValidation<TEntity>
    where TEntity : class
{
    public async Task<bool> Validate(Expression<Func<TEntity, bool>> entityExpression,
        CancellationToken cancellationToken)
    {
        return await context.Set<TEntity>()
            .AsNoTracking()
            .AnyAsync(entityExpression, cancellationToken);
    }
}