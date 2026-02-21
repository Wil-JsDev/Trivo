using Trivo.Domain.Models;

namespace Trivo.Application.Interfaces.Repository;

/// <summary>
/// Defines operations for managing user–skill relationships.
/// </summary>
public interface IUserSkillRepository
{
    /// <summary>
    /// Adds a relationship between a user and a skill.
    /// </summary>
    /// <param name="userSkill">The relationship entity to add.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task AddAsync(UserSkill userSkill, CancellationToken cancellationToken);

    /// <summary>
    /// Adds multiple skills to a user without duplicating existing relationships.
    /// Only new associations will be created.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <param name="skillIds">List of skill identifiers.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>List of newly created relationships.</returns>
    Task<List<UserSkill>> AddSkillsToUserAsync(
        Guid userId,
        List<Guid> skillIds,
        CancellationToken cancellationToken);
}