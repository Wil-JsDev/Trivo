using Trivo.Domain.Models;

namespace Trivo.Application.Interfaces.Repository;

public interface IUserSkillRepository
{
    /// <summary>
    /// Creates the association between a skill and a specific user.
    /// </summary>
    /// <param name="userSkill">The entity to add.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation if necessary.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CreateUserSkillAsync(UserSkill userSkill, CancellationToken cancellationToken);

    /// <summary>
    /// Associates a list of skills with a user, replacing existing associations.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <param name="skillIds">List of skill identifiers to associate.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task<List<UserSkill>> AssociateSkillsToUserAsync(Guid userId, List<Guid> skillIds,
        CancellationToken cancellationToken);
}