using Trivo.Domain.Models;

namespace Trivo.Application.Interfaces.Repository;

/// <summary>
/// Defines operations for managing user–interest relationships.
/// </summary>
public interface IUserInterestRepository
{
    /// <summary>
    /// Adds a relationship between a user and an interest.
    /// </summary>
    /// <param name="userInterest">Relationship entity.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task AddAsync(
        UserInterest userInterest,
        CancellationToken cancellationToken);

    /// <summary>
    /// Adds multiple user–interest relationships.
    /// </summary>
    /// <param name="relationships">Relationships to insert.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task AddRangeAsync(
        List<UserInterest> relationships,
        CancellationToken cancellationToken);

    /// <summary>
    /// Adds new interests to a user without duplicating existing ones.
    /// </summary>
    /// <param name="userId">User identifier.</param>
    /// <param name="interestIds">Interest identifiers.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of newly created relationships.</returns>
    Task<List<UserInterest>> AddInterestsToUserAsync(
        Guid userId,
        List<Guid> interestIds,
        CancellationToken cancellationToken);
}