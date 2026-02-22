namespace Trivo.Application.DTOs.Notification;

public record NotificationDto(
    Guid NotificationId,
    Guid UserId,
    string? Type,
    string? Content,
    bool? IsRead,
    DateTime? CreatedAt,
    DateTime? ReadAt
);