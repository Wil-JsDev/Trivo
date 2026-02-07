namespace Trivo.Domain.Models;

public sealed class Code
{
    public Guid? CodeId { get; set; }

    public Guid? UserId { get; set; }

    public User? User { get; set; }

    public string? Value { get; set; }

    public bool? IsUsed { get; set; } = false;

    public string? Type { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

    public bool? IsRevoked { get; set; } = false;

    public bool? RefreshCode { get; set; }
}