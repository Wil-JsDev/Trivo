using Microsoft.EntityFrameworkCore;
using Trivo.Application.Interfaces.Repository;
using Trivo.Domain.Models;
using Trivo.Infrastructure.Persistence.Context;

namespace Trivo.Infrastructure.Persistence.Repository;

/// <summary>
/// Repository responsible for persistence of user–interest relationships.
/// </summary>
public class UserInterestRepository(TrivoContext context)
    : IUserInterestRepository
{
    public async Task AddUserInterestAsync(
        UserInterest userInterest,
        CancellationToken cancellationToken)
    {
        await context.Set<UserInterest>()
            .AddAsync(userInterest, cancellationToken);
    }

    /// <summary>
    /// Adds multiple user–interest relationships.
    /// </summary>
    public async Task AddRangeUserInterestsAsync(
        List<UserInterest> relationships,
        CancellationToken cancellationToken)
    {
        await context.Set<UserInterest>()
            .AddRangeAsync(relationships, cancellationToken);
    }

    /// <summary>
    /// Adds new interests to a user without duplicating existing ones.
    /// </summary>
    public async Task<List<UserInterest>> AddInterestsToUserAsync(
        Guid userId,
        List<Guid> interestIds,
        CancellationToken cancellationToken)
    {
        // Get already existing relationships
        var existingInterestIds = await context.Set<UserInterest>()
            .AsNoTracking()
            .Where(ui =>
                ui.UserId == userId &&
                ui.InterestId.HasValue &&
                interestIds.Contains(ui.InterestId.Value))
            .Select(ui => ui.InterestId!.Value)
            .ToListAsync(cancellationToken);

        // Determine new interests to insert
        var newInterestIds = interestIds
            .Except(existingInterestIds)
            .ToList();

        if (!newInterestIds.Any())
            return [];

        // Build new relationship entities
        var newRelations = newInterestIds
            .Select(id => new UserInterest
            {
                UserId = userId,
                InterestId = id
            })
            .ToList();

        await context.Set<UserInterest>()
            .AddRangeAsync(newRelations, cancellationToken);

        return newRelations;
    }
}