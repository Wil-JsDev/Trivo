using Trivo.Application.Abstractions.Messages;
using Trivo.Application.DTOs.User;
using Trivo.Application.Pagination;

namespace Trivo.Application.Features.Administrator.Query.GetLatestUsersPaged;

public sealed record GetLatestUsersPagedQuery(
    int PageNumber,
    int PageSize
) : IQuery<PagedResult<UserDto>>;