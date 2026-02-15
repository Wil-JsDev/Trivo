using Trivo.Application.Interfaces.Repository.Base;
using Trivo.Application.Pagination;
using Trivo.Domain.Models;

namespace Trivo.Application.Interfaces.Repository;

/// <summary>
/// Provides data access operations for <see cref="Notification"/> entities.
/// </summary>
public interface INotificationRepository : IGenericRepository<Notification>
{
    /// <summary>
    /// Retrieves a paginated list of notifications belonging to a specific user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="pageNumber">The page number to retrieve.</param>
    /// <param name="pageSize">The number of records per page.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>
    /// A paginated result containing notifications associated with the specified user.
    /// </returns>
    Task<PagedResult<Notification>> GetPagedByUserIdAsync(
        Guid userId,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a notification by its identifier and verifies that it belongs to the specified user.
    /// </summary>
    /// <param name="notificationId">The notification identifier.</param>
    /// <param name="userId">The owner user's identifier.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>
    /// The matching notification if found and owned by the user; otherwise, <c>null</c>.
    /// </returns>
    Task<Notification?> GetByIdAndUserIdAsync(
        Guid notificationId,
        Guid userId,
        CancellationToken cancellationToken);
}