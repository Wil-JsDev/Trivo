namespace Trivo.Domain.Models;

public sealed class InterestCategory
{
    public Guid CategoryId { get; set; }

    public string? Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<Interest>? Interests { get; set; }
}