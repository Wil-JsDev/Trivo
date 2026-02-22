namespace Trivo.Application.DTOs.Email;

public sealed record CodeDto(
    Guid CodeId,
    Guid UserId,
    string Code,
    bool IsUsed,
    DateTime? Expiration
);