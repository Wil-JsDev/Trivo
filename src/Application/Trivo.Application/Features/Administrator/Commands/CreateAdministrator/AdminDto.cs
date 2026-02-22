namespace Trivo.Application.Features.Administrator.Commands.CreateAdministrator;

public sealed record AdminDto(
    Guid? AdminId,
    string? FirstName,
    string? LastName,
    string? Biography,
    string? Email,
    string? Username,
    string? ProfilePhotoUrl,
    DateTime? RegisteredAt
);