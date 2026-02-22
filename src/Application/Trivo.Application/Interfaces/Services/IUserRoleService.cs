using Trivo.Domain.Enums;

namespace Trivo.Application.Interfaces.Services;

public interface IUserRoleService
{
    Task<IList<Roles>> GetRolesAsync(Guid userId, CancellationToken cancellationToken);
}