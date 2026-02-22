using Trivo.Application.DTOs.Notification;
using Trivo.Application.Pagination;
using Trivo.Application.Utils;


namespace Trivo.Application.Interfaces.Services;

public interface INotificationService
{
    Task<ResultT<PagedResult<NotificationDto>>> GetNotificationsAsync(
        Guid userId,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken);

    Task<ResultT<NotificationDto>> MarkAsReadAsync(
        Guid notificationId, 
        Guid userId,
        CancellationToken cancellationToken);

    Task<ResultT<NotificationDto>> DeleteNotificationAsync(
        Guid notificationId,
        Guid userId,
        CancellationToken cancellationToken);

    Task<ResultT<NotificationDto>> CreateNotificationByTypeAsync(
        Guid userId,
        string? notificationType,
        string? content,
        CancellationToken cancellationToken);
}