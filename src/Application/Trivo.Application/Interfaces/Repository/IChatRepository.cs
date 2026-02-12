using Trivo.Application.Interfaces.Repository.Base;
using Trivo.Application.Pagination;
using Trivo.Domain.Models;

namespace Trivo.Application.Interfaces.Repository;

public interface IChatRepository : IGenericRepository<Chat>
{
    Task<IEnumerable<Chat>> Get10RecentChatsAsync(Guid userId, CancellationToken cancellationToken);

    Task<bool> ExistsAsync(Guid chatId, CancellationToken cancellationToken);

    Task<PagedResult<Chat>> GetChatsByUserIdPagedAsync(Guid userId, int page, int pageSize,
        CancellationToken cancellationToken);

    Task<Chat> GetChatByIdAsync(Guid chatId, CancellationToken cancellationToken);

    Task<bool> IsUserInChatAsync(Guid chatId, Guid userId, CancellationToken cancellationToken);

    Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);

    Task<Chat?> FindOneToOneChatAsync(Guid senderId, Guid receiverId, CancellationToken cancellationToken);

    Task<Chat?> GetChatWithUsersAndMessagesAsync(Guid chatId, CancellationToken cancellationToken);
}