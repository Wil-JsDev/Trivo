using Trivo.Application.Interfaces.Repository.Base;
using Trivo.Domain.Models;

namespace Trivo.Application.Interfaces.Repository.Account;

public interface IUserRepository : IGenericRepository<User>
{
    /// <summary>
    /// Verifies if a user's account is confirmed.
    /// </summary>
    /// <param name="id">User ID.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>True if the account is confirmed, false otherwise.</returns>
    Task<bool> IsAccountConfirmedAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Verifies if a username is in use by a user other than the one specified.
    /// </summary>
    /// <param name="username">Username to verify.</param>
    /// <param name="userId">ID of the user to exclude from the verification.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>True if the username is in use, false otherwise.</returns>
    Task<bool> IsUsernameInUseAsync(string username, Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the status of a user given their ID.
    /// </summary>
    /// <param name="userId">User ID.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>User status or null if it does not exist.</returns>
    Task<string?> GetUserStatusAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Searches for a user by their email.
    /// </summary>
    /// <param name="email">User email.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>The found user or null if they do not exist.</returns>
    Task<User> GetByUserEmailAsync(string email, CancellationToken cancellationToken);

    /// <summary>
    /// Searches for a user by their username.
    /// </summary>
    /// <param name="username">Username to search for.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>The found user or null if they do not exist.</returns>
    Task<User> GetByUsernameAsync(string username, CancellationToken cancellationToken);

    /// <summary>
    /// Filters and retrieves users who have at least one of the specified interests or skills.
    /// </summary>
    /// <param name="interestIds">Optional list of interest IDs to filter by.</param>
    /// <param name="skillIds">Optional list of skill IDs to filter by.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A collection of <see cref="User"/> objects matching the specified interests or skills.</returns>
    Task<IEnumerable<User>> FilterByInterestsAndSkillsAsync(
        List<Guid>? interestIds,
        List<Guid>? skillIds,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets a user's skills given their ID.
    /// </summary>
    /// <param name="userId">User ID.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>A list of skill IDs belonging to the user.</returns>
    Task<List<Guid?>> GetUserSkillsAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets a user's interests given their ID.
    /// </summary>
    /// <param name="userId">User ID.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>A list of interest IDs belonging to the user.</returns>
    Task<List<Guid?>> GetUserInterestsAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Verifies if an email is in use, excluding a specific user.
    /// </summary>
    /// <param name="email">Email to verify.</param>
    /// <param name="excludeUserId">ID of the user to exclude.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<bool> IsEmailInUseAsync(string email, Guid excludeUserId, CancellationToken cancellationToken);

    /// <summary>
    /// Updates a user's password.
    /// </summary>
    /// <param name="user">User whose password is being updated.</param>
    /// <param name="newHashedPassword">The new hashed password.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task UpdatePasswordAsync(User user, string newHashedPassword, CancellationToken cancellationToken);

    /// <summary>
    /// Verifies if an email exists in the database.
    /// </summary>
    /// <param name="email">Email to verify.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken);

    /// <summary>
    /// Verifies if a username exists in the database.
    /// </summary>
    /// <param name="username">Username to verify.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken);

    /// <summary>
    /// Gets a user with all their related information, such as interests and skills.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation if necessary.</param>
    /// <returns>A user with their full details.</returns>
    Task<User> GetUserDetailsByIdAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets a specific user along with their interests and skills.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A user with their interests or null if not found.</returns>
    Task<User?> GetUserWithInterestsAndSkillsAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets all users including their interests and skills.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A collection of users with their interests and skills.</returns>
    Task<IEnumerable<User>> GetAllUsersWithInterestsAndSkillsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Gets the list of interests associated with a specific user.
    /// </summary>
    /// <param name="userId">The user ID.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A collection of <see cref="UserInterest"/> objects.</returns>
    Task<IEnumerable<UserInterest>> GetInterestsByUserIdAsync(Guid userId,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets the list of skills associated with a specific user.
    /// </summary>
    /// <param name="userId">The user ID.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A collection of <see cref="UserSkill"/> objects.</returns>
    Task<IEnumerable<UserSkill>> GetSkillsByUserIdAsync(Guid userId,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets a list of potential users for matching, based on the role and current user ID.
    /// </summary>
    /// <param name="currentUserId">ID of the user performing the search.</param>
    /// <param name="role">The user role to filter targets (e.g., "Expert", "Apprentice").</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A collection of <see cref="User"/> objects as potential targets.</returns>
    Task<IEnumerable<User>> GetTargetUsersAsync(Guid currentUserId, string role,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets the role assigned to a specific user.
    /// </summary>
    /// <param name="userId">The user ID.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A string representing the user's role.</returns>
    Task<string> GetUserRoleAsync(Guid userId, CancellationToken cancellationToken);

    Task<User?> GetExpertAndRecruiterRelationshipsByUserIdAsync(Guid userId, CancellationToken cancellationToken);

    Task<User?> GetByIdWithRelationshipsAsync(Guid id, CancellationToken cancellationToken);
}