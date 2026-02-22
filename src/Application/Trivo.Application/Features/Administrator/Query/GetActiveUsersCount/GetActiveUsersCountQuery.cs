using Trivo.Application.Abstractions.Messages;

namespace Trivo.Application.Features.Administrator.Query.GetActiveUsersCount;

public sealed record GetActiveUsersCountQuery()
    : IQuery<ActiveUsersCountDto>;