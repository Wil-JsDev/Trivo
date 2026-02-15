using Microsoft.EntityFrameworkCore;
using Trivo.Application.Interfaces.Repository;
using Trivo.Domain.Models;
using Trivo.Infrastructure.Persistence.Context;

namespace Trivo.Infrastructure.Persistence.Repository;

/// <summary>
/// Repository responsible for managing persistence of user–skill relationships.
/// </summary>
public class UserSkillRepository(TrivoContext context)
    : IUserSkillRepository
{
    public async Task AddUserSkillAsync(
        UserSkill userSkill,
        CancellationToken cancellationToken)
    {
        await context.Set<UserSkill>()
            .AddAsync(userSkill, cancellationToken);
    }

    public async Task<List<UserSkill>> AddSkillsToUserAsync(
        Guid userId,
        List<Guid> skillIds,
        CancellationToken cancellationToken)
    {
        // Get existing skill IDs already linked to the user
        var existingSkillIds = await context.Set<UserSkill>()
            .AsNoTracking()
            .Where(us => us.UserId == userId &&
                         us.SkillId.HasValue &&
                         skillIds.Contains(us.SkillId.Value))
            .Select(us => us.SkillId!.Value)
            .ToListAsync(cancellationToken);

        // Determine new skills to add
        var newSkillIds = skillIds
            .Except(existingSkillIds)
            .ToList();

        if (!newSkillIds.Any())
            return [];

        // Create new relationships
        var newRelations = newSkillIds
            .Select(id => new UserSkill
            {
                UserId = userId,
                SkillId = id
            })
            .ToList();

        await context.Set<UserSkill>()
            .AddRangeAsync(newRelations, cancellationToken);

        return newRelations;
    }
}