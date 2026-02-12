using Trivo.Application.Interfaces.Repository.Base;
using Trivo.Application.Pagination;
using Trivo.Domain.Models;

namespace Trivo.Application.Interfaces.Repository;

public interface IMessageRepository : IGenericRepository<Message>
{
    Task<Message?> GetLastMessageByChatIdAsync(Guid chatId, CancellationToken cancellationToken);

    // Task<PagedResult<MessageDto>> GetMessagesByChatIdPagedAsync(Guid chatId, int page, int pageSize, CancellationToken cancellationToken);

    Task<Message?> GetUserWhoOwnsTheMessageAsync(Guid messageId, CancellationToken cancellationToken);
}