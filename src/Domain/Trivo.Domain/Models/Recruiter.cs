using Trivo.Domain.Common;

namespace Trivo.Domain.Models;

public sealed class Recruiter : BaseEntity
{
    public string? CompanyName { get; set; }

    public Guid? UserId { get; set; }

    public User? User { get; set; }

    public ICollection<Match>? Matches { get; set; }
}