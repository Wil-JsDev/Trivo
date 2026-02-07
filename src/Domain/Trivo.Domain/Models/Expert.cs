using Trivo.Domain.Common;

namespace Trivo.Domain.Models;

public sealed class Expert : BaseEntity
{
    public Guid? UserId { get; set; }

    public bool? AvailableForProjects { get; set; }

    public bool? IsHired { get; set; }

    public User? User { get; set; }

    public ICollection<Match>? Matches { get; set; }
}