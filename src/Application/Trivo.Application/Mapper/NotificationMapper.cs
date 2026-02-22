using Trivo.Application.DTOs.Notification;
using Trivo.Domain.Models;

namespace Trivo.Application.Mapper;

public static class NotificationMapper
{
    public static Notification MapToEntity(CreateNotificationDto dto)
    {
        return new Notification
        {
            NotificationId = Guid.NewGuid(),
            UserId = dto.UserId,
            Type = dto.NotificationType,
            Content = dto.Content,
            IsRead = false,
            ReadAt = DateTime.UtcNow
        };
    }

    public static NotificationDto MapToDto(Notification entity)
    {
        return new NotificationDto(
            NotificationId: entity.NotificationId ?? Guid.Empty,
            UserId: entity.UserId ?? Guid.Empty,
            Type: entity.Type ?? string.Empty,
            Content: entity.Content ?? string.Empty,
            IsRead: entity.IsRead ?? false,
            CreatedAt: entity.CreatedAt ?? DateTime.UtcNow,
            ReadAt: entity.ReadAt
        );
    }

    public static List<NotificationDto> MapToDtoList(IEnumerable<Notification> notifications)
    {
        return notifications?
            .Select(MapToDtoInternal)
            .ToList() ?? [];
    }

    #region Private Methods

    private static NotificationDto MapToDtoInternal(Notification notification)
    {
        return new NotificationDto(
            NotificationId: notification.NotificationId ?? Guid.Empty,
            UserId: notification.UserId ?? Guid.Empty,
            Type: notification.Type,
            Content: notification.Content,
            IsRead: notification.IsRead ?? false,
            CreatedAt: notification.CreatedAt,
            ReadAt: notification.ReadAt
        );
    }

    #endregion
}