namespace Trivo.Application.DTOs;

public sealed record MessageDto(
    Guid MessageId,
    Guid ChatId,
    string? Content,
    string? Status,
    DateTime? SentDate,
    Guid SenderId,
    Guid ReceiverId,
    string? MessageType
);