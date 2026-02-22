using Trivo.Application.DTOs.Interests;
using Trivo.Application.DTOs.Skills;
using Trivo.Application.DTOs.User;

namespace Trivo.Application.DTOs.Recruiter;

public record RecruiterAiRecommendationDto(
    Guid RecruiterId,
    Guid UserId,
    string? FirstName,
    string? LastName,
    string? Location,
    string? Biography,
    string? ProfilePicture,
    string? Position,
    List<InterestWithIdDto> Interests,
    List<SkillWithIdDto> Skills,
    string? CompanyName
) : UserAiRecommendationDto(UserId, FirstName, LastName, Location, Biography, Position, ProfilePicture, Interests,
    Skills);