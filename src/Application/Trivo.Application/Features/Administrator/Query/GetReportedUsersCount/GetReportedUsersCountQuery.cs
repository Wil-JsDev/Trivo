using Trivo.Application.Abstractions.Messages;

namespace Trivo.Application.Features.Administrator.Query.GetReportedUsersCount;

public sealed record GetReportedUsersCountQuery()
    : IQuery<ReportedUsersCountDto>;