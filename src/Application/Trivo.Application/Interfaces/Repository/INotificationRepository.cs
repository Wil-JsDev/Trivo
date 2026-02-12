using Trivo.Application.Interfaces.Repository.Base;
using Trivo.Application.Pagination;
using Trivo.Domain.Models;

namespace Trivo.Application.Interfaces.Repository;

public interface INotificationRepository : IGenericRepository<Notification>
{
    Task<PagedResult<Notification>> GetNotificationsByUserIdPagedAsync(
        Guid userId,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken);

    Task<Notification?> GetByIdAndUserAsync(
        Guid notificationId,
        Guid userId,
        CancellationToken cancellationToken);
}