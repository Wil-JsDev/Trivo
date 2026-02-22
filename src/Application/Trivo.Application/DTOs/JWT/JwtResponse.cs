namespace Trivo.Application.DTOs.JWT;

public sealed record JwtResponse(bool HasError, string? Error);