namespace Trivo.Domain.Models;

public sealed class Notification
{
    public Guid? NotificationId { get; set; }

    public Guid? UserId { get; set; }

    public User? User { get; set; }

    public string? Type { get; set; }

    public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

    public bool? IsRead { get; set; }

    public DateTime? ReadAt { get; set; }
}