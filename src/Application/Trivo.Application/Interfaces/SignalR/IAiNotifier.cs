using Trivo.Application.DTOs.User;

namespace Trivo.Application.Interfaces.SignalR;

public interface IAiNotifier
{
    Task NotifyRecommendationsAsync(Guid userId, IEnumerable<UserAiRecommendationDto>? recommendations);

    Task NotifyNewRecommendationsAsync(Guid userId, IEnumerable<UserAiRecommendationDto>? recommendations);
}