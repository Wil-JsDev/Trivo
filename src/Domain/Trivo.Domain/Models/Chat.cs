using Trivo.Domain.Common;

namespace Trivo.Domain.Models;

public sealed class Chat : BaseEntity
{
    public string? ChatType { get; set; }

    public bool? IsActive { get; set; }

    public ICollection<Message> Messages { get; set; } = new List<Message>();

    public ICollection<ChatUser>? ChatUsers { get; set; }
}