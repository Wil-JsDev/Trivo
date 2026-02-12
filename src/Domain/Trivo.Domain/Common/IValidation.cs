using System.Linq.Expressions;

namespace Trivo.Domain.Common;

public interface IValidation<TEntity> where TEntity : class
{
    Task<bool> Validate(Expression<Func<TEntity, bool>> entityExpression, CancellationToken cancellationToken);
}