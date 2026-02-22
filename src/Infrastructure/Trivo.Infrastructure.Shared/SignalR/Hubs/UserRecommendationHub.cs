using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Trivo.Application.Interfaces.SignalR;

namespace Trivo.Infrastructure.Shared.SignalR.Hubs;

[Authorize]
public class UserRecommendationHub(
    ILogger<UserRecommendationHub> logger,
    IMediator mediator
) : Hub<IUserRecommendationHub>
{
    public override async Task OnConnectedAsync()
    {
        var userIdentifier = Context.UserIdentifier;

        logger.LogInformation("🔌 User connected:");
        logger.LogInformation("- UserIdentifier (SignalR): {UserIdentifier}", userIdentifier);

        if (!Guid.TryParse(userIdentifier, out var userId))
        {
            logger.LogError("UserIdentifier is not a valid GUID");
            return;
        }

        var httpContext = Context.GetHttpContext();
        var query = httpContext?.Request.Query;

        var pageNumberString = query?["pageNumber"];
        var pageSizeString = query?["pageSize"];

        var pageNumber = int.TryParse(pageNumberString, out var pn) ? pn : 1;
        var pageSize = int.TryParse(pageSizeString, out var ps) ? ps : 5;

        logger.LogInformation("- UserId: {UserId}", userId);

        var result = await mediator.Send(new GetUserAiRecommendationsQuery(
            userId,
            PageNumber: pageNumber,
            PageSize: pageSize
        ));

        if (!result.IsSuccess)
        {
            logger.LogWarning("No recommendations found for user {UserId}.", userId);
            await Clients.User(userId.ToString()).ReceiveRecommendationsAsync(new List<UserIARecommendationDto>());
            await base.OnConnectedAsync();
            return;
        }

        await Clients.User(userId.ToString())
            .ReceiveRecommendationsAsync(result.Value.Items);

        await base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        logger.LogInformation("User disconnected: {UserIdentifier}", Context.UserIdentifier);
        return base.OnDisconnectedAsync(exception);
    }
}