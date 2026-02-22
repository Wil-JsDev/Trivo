using Trivo.Application.Interfaces.Repository.Base;
using Trivo.Domain.Enums;
using Trivo.Domain.Models;

namespace Trivo.Application.Interfaces.Repository;

/// <summary>
/// Repository to handle the Match entity.
/// Includes specific methods to query matches between experts and recruiters.
/// </summary>
public interface IMatchRepository : IGenericRepository<Match>
{
    /// <summary>
    /// Gets a match between an expert and a recruiter if it exists.
    /// </summary>
    /// <param name="expertId">The expert's ID.</param>
    /// <param name="recruiterId">The recruiter's ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The found match, or null if it does not exist.</returns>
    Task<Match?> GetAsync(Guid expertId, Guid recruiterId, CancellationToken cancellationToken);

    /// <summary>
    /// Verifies if a match exists between an expert and a recruiter.
    /// </summary>
    /// <param name="expertId">The expert's ID.</param>
    /// <param name="recruiterId">The recruiter's ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the match exists; false otherwise.</returns>
    Task<bool> ExistsAsync(Guid expertId, Guid recruiterId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the pending matches where the user acts as an expert.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation if necessary.</param>
    /// <returns>A list of pending matches associated with the user as an expert.</returns>
    Task<IEnumerable<Match>> GetAsExpertAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the pending matches where the user acts as a recruiter.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation if necessary.</param>
    /// <returns>A list of pending matches associated with the user as a recruiter.</returns>
    Task<IEnumerable<Match>> GetAsRecruiterAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets a match by its unique identifier.
    /// </summary>
    Task<Match?> GetByIdAsync(Guid matchId, CancellationToken cancellationToken);

    /// <summary>
    /// Updates the status of a match.
    /// </summary>
    /// <param name="matchId">The identifier of the match.</param>
    /// <param name="status">The new update status for the match.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task UpdateStatusAsync(Guid matchId, MatchUpdateStatus? status, CancellationToken cancellationToken);
}