using Trivo.Application.DTOs.Match;

namespace Trivo.Application.Interfaces.SignalR;

public interface IMatchHub
{
    Task ReceiveMatchesAsync(IEnumerable<MatchDto> matches);

    Task ReceiveNewMatchesAsync(IEnumerable<MatchDto> matches);

    Task ReceiveMatchCompletedAsync(Guid matchId, MatchDetailsDto matchDetails);

    Task ReceiveMatchRejectedAsync(Guid matchId, MatchDetailsDto matchDetails);
}