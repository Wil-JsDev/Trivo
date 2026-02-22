using Trivo.Application.Abstractions.Messages;

namespace Trivo.Application.Features.Administrator.Query.GetCompletedMatchesCount;

public sealed record GetCompletedMatchesCountQuery()
    : IQuery<CompletedMatchesCountDto>;