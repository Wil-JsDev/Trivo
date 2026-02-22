using Trivo.Domain.Common;

namespace Trivo.Domain.Models;

public class Match : BaseEntity
{
    public Guid? RecruiterId { get; set; }

    public Guid? ExpertId { get; set; }

    public string? ExpertStatus { get; set; }

    public string? RecruiterStatus { get; set; }

    public string? MatchStatus { get; set; }

    public Recruiter? Recruiter { get; set; }

    public Expert? Expert { get; set; }
}