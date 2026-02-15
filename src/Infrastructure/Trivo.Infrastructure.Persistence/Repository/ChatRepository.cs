using Microsoft.EntityFrameworkCore;
using Trivo.Application.Interfaces.Repository;
using Trivo.Application.Pagination;
using Trivo.Domain.Enums;
using Trivo.Domain.Models;
using Trivo.Infrastructure.Persistence.Base;
using Trivo.Infrastructure.Persistence.Context;

namespace Trivo.Infrastructure.Persistence.Repository;

public class ChatRepository(TrivoContext context) : GenericRepository<Chat>(context), IChatRepository
{
    public async Task<IEnumerable<Chat>> Get10RecentChatsAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await Context.Set<ChatUser>()
            .Where(cu => cu.UserId == userId)
            .OrderByDescending(cu => cu.Chat!.CreatedAt)
            .Select(cu => cu.Chat!)
            .Include(c => c.ChatUsers)!
            .ThenInclude(cu => cu.User)
            .Take(10)
            .ToListAsync(cancellationToken);
    }

    public async Task<PagedResult<Chat>> GetChatsByUserIdPagedAsync(
        Guid userId, int page, int pageSize, CancellationToken cancellationToken)
    {
        var total = await Context.Set<ChatUser>()
            .Where(cu => cu.UserId == userId)
            .CountAsync(cancellationToken);

        var chats = await Context.Set<ChatUser>()
            .Where(cu => cu.UserId == userId)
            .OrderByDescending(cu => cu.JoinedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(cu => new Chat
            {
                Id = cu.Chat!.Id,
                CreatedAt = cu.Chat.CreatedAt,
                ChatUsers = cu.Chat.ChatUsers!.Select(c => new ChatUser
                {
                    UserId = c.UserId,
                    ChatName = c.ChatName,
                    User = new User
                    {
                        Id = c.User!.Id,
                        Username = c.User.Username,
                        FirstName = c.User.FirstName,
                        LastName = c.User.LastName,
                        ProfilePicture = c.User.ProfilePicture
                    }
                }).ToList(),
                Messages = cu.Chat.Messages
                    .OrderByDescending(m => m.SentAt)
                    .Take(1)
                    .Select(m => new Message
                    {
                        MessageId = m.MessageId,
                        Content = m.Content,
                        SentAt = m.SentAt,
                        Status = m.Status,
                        SenderId = m.SenderId,
                        ChatId = m.ChatId,
                        Type = m.Type
                    }).ToList()
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return new PagedResult<Chat>(chats, total, page, pageSize);
    }

    public async Task<Chat> GetChatByIdAsync(Guid chatId, CancellationToken cancellationToken)
        => (await Context.Set<Chat>()
            .Include(c => c.ChatUsers)!
            .ThenInclude(cu => cu.User)
            .Include(c => c.Messages)
            .Where(c => c.Id == chatId)
            .FirstOrDefaultAsync(cancellationToken))!;

    public async Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
        => await Context.Set<User>()
            .Where(u => u.Id == userId)
            .Select(u => new User
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                ProfilePicture = u.ProfilePicture
            })
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<bool> IsUserInChatAsync(Guid chatId, Guid userId, CancellationToken cancellationToken)
        => await Context.Set<ChatUser>()
            .AnyAsync(c => c.ChatId == chatId && c.UserId == userId, cancellationToken);

    public async Task<bool> ExistsAsync(Guid chatId, CancellationToken cancellationToken)
        => await Context.Set<Chat>()
            .AnyAsync(c => c.Id == chatId, cancellationToken);

    public async Task<Chat?> FindOneToOneChatAsync(Guid senderId, Guid receiverId, CancellationToken cancellationToken)
    {
        return await Context.Set<Chat>()
            .Include(c => c.ChatUsers)!
            .ThenInclude(cu => cu.User)
            .Include(c => c.Messages)
            .ThenInclude(m => m.Sender)
            .Include(c => c.Messages)
            .ThenInclude(m => m.Receiver)
            .Where(c => c.ChatType == ChatType.Private.ToString())
            .Where(c => c.ChatUsers!.Any(cu => cu.UserId == senderId) &&
                        c.ChatUsers!.Any(cu => cu.UserId == receiverId))
            .OrderByDescending(c => c.Messages.Max(m => m.SentAt))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Chat?> GetChatWithUsersAndMessagesAsync(Guid chatId, CancellationToken cancellationToken)
    {
        return await Context.Set<Chat>()
            .Where(c => c.Id == chatId)
            .Select(c => new Chat
            {
                Id = c.Id,
                CreatedAt = c.CreatedAt,
                ChatUsers = c.ChatUsers!.Select(cu => new ChatUser
                {
                    UserId = cu.UserId,
                    ChatName = cu.ChatName,
                    User = new User
                    {
                        Id = cu.User!.Id,
                        Username = cu.User.Username,
                        FirstName = cu.User.FirstName,
                        LastName = cu.User.LastName,
                        ProfilePicture = cu.User.ProfilePicture
                    }
                }).ToList(),
                Messages = c.Messages
                    .OrderByDescending(m => m.SentAt)
                    .Select(m => new Message
                    {
                        MessageId = m.MessageId,
                        Content = m.Content,
                        SentAt = m.SentAt,
                        Status = m.Status,
                        Sender = new User
                        {
                            Id = m.Sender!.Id,
                            FirstName = m.Sender.FirstName,
                            LastName = m.Sender.LastName,
                            ProfilePicture = m.Sender.ProfilePicture
                        },
                        Receiver = new User
                        {
                            Id = m.Receiver!.Id,
                            FirstName = m.Receiver.FirstName,
                            LastName = m.Receiver.LastName,
                            ProfilePicture = m.Receiver.ProfilePicture
                        }
                    }).ToList()
            })
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }
}