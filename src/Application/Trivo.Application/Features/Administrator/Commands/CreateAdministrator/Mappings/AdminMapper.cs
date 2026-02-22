namespace Trivo.Application.Features.Administrator.Commands.CreateAdministrator.Mappings;

/// <summary>
/// Provides mapping methods for converting Administrator domain entities
/// into application DTOs.
/// 
/// This mapper should be used when returning administrator data from the
/// application layer to external consumers such as API responses,
/// queries, or integration outputs.
/// 
/// Responsibility:
/// - Domain → DTO transformation
/// - Output shaping
/// - Read model projection
///
/// Design Notes:
/// - Stateless
/// - Pure mapping logic
/// - Safe to reuse across features
///
/// Usage Context:
/// Queries, responses, handlers, projections.
/// </summary>
public static class AdminMapper
{
    public static AdminDto ToDto(Domain.Models.Administrator admin)
    {
        return new AdminDto(
            AdminId: admin.Id,
            FirstName: admin.FirstName,
            LastName: admin.LastName,
            Biography: admin.Biography,
            Email: admin.Email,
            Username: admin.Username,
            ProfilePhotoUrl: admin.ProfilePicture,
            RegisteredAt: admin.CreatedAt
        );
    }
}