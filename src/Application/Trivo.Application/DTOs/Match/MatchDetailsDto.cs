namespace Trivo.Application.DTOs.Match;

public sealed record MatchDetailsDto(
    Guid MatchId,
    Guid RecruiterId,
    Guid ExpertId,
    string ExpertStatus,
    string RecruiterStatus,
    string MatchStatus,
    DateTime? CreatedAt
);