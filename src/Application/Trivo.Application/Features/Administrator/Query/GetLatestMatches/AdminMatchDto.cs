namespace Trivo.Application.Features.Administrator.Query.GetLatestMatches;

public sealed record AdminMatchDto(
    Guid MatchId,
    Guid RecruiterId,
    Guid ExpertId,
    string? ExpertStatus,
    string? RecruiterStatus,
    string? MatchStatus,
    DateTime? CreatedAt,
    RecruiterMatchDto? Recruiter,
    ExpertMatchDto? Expert
);

public sealed record RecruiterMatchDto(
    string? FirstName,
    string LastName
);

public sealed record ExpertMatchDto(
    string? FirstName,
    string LastName
);