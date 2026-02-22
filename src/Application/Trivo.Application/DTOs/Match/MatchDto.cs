using Trivo.Application.DTOs.Experts;
using Trivo.Application.DTOs.Recruiter;

namespace Trivo.Application.DTOs.Match;

public record MatchDto(
    Guid MatchId,
    Guid? RecruiterId,
    Guid? ExpertId,
    string? ExpertStatus,
    string? RecruiterStatus,
    string? MatchStatus,
    DateTime? CreatedAt,
    ExpertAiRecommendationDto? ExpertDto,
    RecruiterAiRecommendationDto? RecruiterDto
    );