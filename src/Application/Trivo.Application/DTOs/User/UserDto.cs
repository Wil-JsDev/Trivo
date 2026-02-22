namespace Trivo.Application.DTOs.User;

public sealed record UserDto(
    Guid Id,
    string? FirstName,
    string? LastName,
    string? ProfilePictureUrl
);