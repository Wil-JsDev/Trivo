using Trivo.Application.Interfaces.Repository.Base;
using Trivo.Application.Pagination;
using Trivo.Domain.Models;

namespace Trivo.Application.Interfaces.Repository.Account;

public interface IAdministratorRepository : IGenericRepository<Administrator>
{
    Task BanUserAsync(Guid userId, CancellationToken cancellationToken);

    Task UnbanUserAsync(Guid userId, CancellationToken cancellationToken);

    Task<PagedResult<Report>> GetLatestReportsPagedAsync(
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken);

    Task<IEnumerable<User>> GetLast10BannedUsersAsync(CancellationToken cancellationToken);

    Task<bool> IsUsernameInUseAsync(string username, Guid userId, CancellationToken cancellationToken);

    Task<Administrator> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task<bool> IsEmailInUseAsync(string email, Guid excludeUserId, CancellationToken cancellationToken);

    Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken);

    Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken);

    Task UpdatePasswordAsync(Administrator admin, string newPassword);

    Task<PagedResult<User>> GetLatestUsersPagedAsync(
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken);

    Task<PagedResult<Match>> GetLatestMatchesPagedAsync(
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken);

    Task<int> CountCompletedMatchesAsync(CancellationToken cancellationToken);

    Task<int> CountActiveUsersAsync(CancellationToken cancellationToken);

    Task<int> GetReportedUsersCountAsync(CancellationToken cancellationToken);
}