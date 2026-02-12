using Trivo.Domain.Models;

namespace Trivo.Application.Interfaces.Repository;

/// <summary>
/// Defines operations to manage the association between users and interests.
/// </summary>
public interface IUserInterestRepository
{
    /// <summary>
    /// Creates a new relationship between a user and an interest.
    /// </summary>
    /// <param name="userInterest">UserInterest relationship entity containing the necessary IDs.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task CreateUserInterestAsync(UserInterest userInterest, CancellationToken cancellationToken);

    /// <summary>
    /// Creates multiple relationships between users and interests in the database.
    /// </summary>
    /// <param name="relationships">List of <see cref="UserInterest"/> objects representing the relationships to create.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation if necessary.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CreateMultipleUserInterestsAsync(List<UserInterest> relationships, CancellationToken cancellationToken);

    /// <summary>
    /// Associates a list of interests with a specific user, replacing existing associations.
    /// </summary>
    /// <param name="userId">Unique identifier of the user.</param>
    /// <param name="interestIds">List of interest identifiers to associate with the user.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation if necessary.</param>
    /// <returns>
    /// A task representing the asynchronous operation that returns the updated list
    /// of associations between the user and their interests.
    /// </returns>
    Task<List<UserInterest>> AssociateInterestsToUserAsync(Guid userId, List<Guid> interestIds,
        CancellationToken cancellationToken);
}