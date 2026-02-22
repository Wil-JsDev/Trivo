namespace Trivo.Application.DTOs.User;

public record UserChatDto(
    Guid UserId,
    string Username,
    string FullName,
    string? ProfilePicture
);