namespace Trivo.Application.DTOs.Notification;

public sealed record CreateNotificationDto(
    Guid UserId,
    string? NotificationType,
    string? Content
);