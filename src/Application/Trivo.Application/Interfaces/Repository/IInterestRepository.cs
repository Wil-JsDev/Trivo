using Trivo.Application.Pagination;
using Trivo.Domain.Common;
using Trivo.Domain.Models;

namespace Trivo.Application.Interfaces.Repository;

/// <summary>
/// Defines operations to manage interests within the system.
/// </summary>
public interface IInterestRepository : IValidation<Interest>
{
    /// <summary>
    /// Creates a collection of interests in the database.
    /// </summary>
    /// <param name="interest">The interest entity to create.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation if necessary.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CreateInterestAsync(Interest interest, CancellationToken cancellationToken);

    /// <summary>
    /// Updates the interests associated with a specific user.
    /// </summary>
    /// <param name="userId">ID of the user to update.</param>
    /// <param name="interestIds">IDs of the new interests to be assigned to the user.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>An asynchronous task.</returns>
    Task UpdateUserInterestsAsync(Guid userId, List<Guid> interestIds, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a paged list of existing interests in the database.
    /// </summary>
    /// <param name="pageNumber">The page number to query (starting at 1).</param>
    /// <param name="pageSize">Number of elements per page.</param>
    /// <param name="cancellationToken">Cancellation token for the asynchronous operation.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The result contains a 
    /// <see cref="PagedResult{Interest}"/> object with the interests for the requested page.
    /// </returns>
    Task<PagedResult<Interest>> GetInterestsPagedAsync(int pageNumber, int pageSize,
        CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a list of users associated with interests belonging to a specific category.
    /// </summary>
    /// <param name="categoryId">Unique identifier of the interest category.</param>
    /// <param name="cancellationToken">Cancellation token for the asynchronous operation.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The result contains a collection of users
    /// related to at least one interest within the specified category.
    /// </returns>
    Task<IEnumerable<User>> GetUsersByInterestCategoryAsync(Guid categoryId, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a paged list of interests filtered by one or more specific categories.
    /// </summary>
    /// <param name="categoryIds">Collection of category identifiers.</param>
    /// <param name="pageNumber">The page number to query (starting at 1).</param>
    /// <param name="pageSize">Number of elements per page.</param>
    /// <param name="cancellationToken">Cancellation token for the asynchronous operation.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The result contains a
    /// <see cref="PagedResult{Interest}"/> object with the interests associated with the indicated categories.
    /// </returns>
    Task<PagedResult<Interest>> GetInterestsByCategoriesPagedAsync(IEnumerable<Guid> categoryIds, int pageNumber,
        int pageSize, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a specific interest by its unique identifier.
    /// </summary>
    /// <param name="interestId">The identifier of the interest to search for.</param>
    /// <param name="cancellationToken">Cancellation token for the asynchronous operation.</param>
    /// <returns>A task that returns the found interest or null if it does not exist.</returns>
    Task<Interest> GetByIdAsync(Guid interestId, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves users who are associated with any of the specified interests.
    /// </summary>
    /// <param name="interestIds">Collection of interest identifiers to filter users.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation if necessary.</param>
    /// <returns>A task that returns a collection of users associated with the provided interests.</returns>
    Task<IEnumerable<User>>
        GetUsersByInterestsAsync(IEnumerable<Guid> interestIds, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a collection of interests belonging to one or several specific categories.
    /// </summary>
    /// <param name="categoryIds">Collection of category IDs.</param>
    /// <param name="pageNumber">The page number to query.</param>
    /// <param name="pageSize">Number of elements per page.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation containing a paged result of interests.</returns>
    Task<PagedResult<Interest>> GetInterestsByCategoryIdAsync(
        IEnumerable<Guid> categoryIds,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken);

    /// <summary>
    /// Verifies if an interest already exists with the specified name, regardless of the category.
    /// </summary>
    /// <param name="name">Name of the interest to validate.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>
    /// <c>true</c> if an interest with that name already exists; otherwise, <c>false</c>.
    /// </returns>
    Task<bool> NameExistsAsync(string name, CancellationToken cancellationToken);

    /// <summary>
    /// Verifies if an interest already exists with the specified name within a specific category.
    /// </summary>
    /// <param name="name">Name of the interest to validate.</param>
    /// <param name="categoryId">ID of the category where the existence of the interest will be validated.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>
    /// <c>true</c> if an interest with that name already exists in the specified category; otherwise, <c>false</c>.
    /// </returns>
    Task<bool> CategoryNameExistsAsync(string name, Guid categoryId, CancellationToken cancellationToken);

    /// <summary>
    /// Searches for interests whose name contains the specified text, case-insensitive.
    /// </summary>
    /// <param name="interestName">Text to search for within the interest names.</param>
    /// <param name="cancellationToken">Token to cancel the operation early.</param>
    /// <returns>A collection of interests that partially match the provided text.</returns>
    Task<IEnumerable<Interest>> SearchInterestsByNameAsync(string interestName, CancellationToken cancellationToken);
}