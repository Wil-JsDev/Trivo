using Trivo.Application.DTOs.User;

namespace Trivo.Application.Interfaces.SignalR;

public interface IUserRecommendationHub
{
    Task ReceiveRecommendationsAsync(IEnumerable<UserAiRecommendationDto>? recommendations);

    Task NotifyNewRecommendationAsync(IEnumerable<UserAiRecommendationDto>? recommendations);
}