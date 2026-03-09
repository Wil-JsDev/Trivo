using Trivo.Application.Abstractions.Messages;
using Trivo.Application.DTOs.Chat;
using Trivo.Application.Pagination;

namespace Trivo.Application.Features.Chat.Query.GetChatPagination;

public sealed record GetChatPaginationQuery(
    Guid UserId,
    int PageNumber,
    int PageSize
) : IQuery<PagedResult<ChatDto>>;