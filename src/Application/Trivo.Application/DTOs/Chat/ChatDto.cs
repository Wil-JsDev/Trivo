using Trivo.Application.DTOs.User;

namespace Trivo.Application.DTOs.Chat;

public sealed record ChatDto(
    Guid Id,
    List<UserChatDto> Participants,
    DateTime CreatedAt,
    string Name,
    MessageDto? LastMessage
);