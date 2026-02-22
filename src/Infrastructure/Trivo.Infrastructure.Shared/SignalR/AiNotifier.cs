using Microsoft.AspNetCore.SignalR;
using Trivo.Application.DTOs.User;
using Trivo.Application.Interfaces.SignalR;
using Trivo.Infrastructure.Shared.SignalR.Hubs;

namespace Trivo.Infrastructure.Shared.SignalR;

public class AiNotifier(IHubContext<UserRecommendationHub, IUserRecommendationHub> hubContext) : IAiNotifier
{
    public async Task NotifyRecommendationsAsync(Guid userId, IEnumerable<UserAiRecommendationDto>? recommendations)
    {
        Console.WriteLine($"📢 Notifying user {userId} with {recommendations?.Count() ?? 0} recommendations.");
        
        await hubContext.Clients.User(userId.ToString())
            .ReceiveRecommendationsAsync(recommendations);
    }

    public async Task NotifyNewRecommendationsAsync(Guid userId, IEnumerable<UserAiRecommendationDto>? recommendations)
    {
        await hubContext.Clients.User(userId.ToString())
            .NotifyNewRecommendationAsync(recommendations);
    }
}