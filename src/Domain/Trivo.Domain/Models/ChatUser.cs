namespace Trivo.Domain.Models;

public sealed class ChatUser
{
    public Guid? ChatId { get; set; }

    public Chat? Chat { get; set; }

    public string? ChatName { get; set; }

    public Guid? UserId { get; set; }

    public User? User { get; set; }

    public DateTime? JoinedAt { get; set; } = DateTime.UtcNow;

    public DateTime? LeftAt { get; set; }
}