namespace Trivo.Application.Interfaces.Services;

public interface IGetRecruiterIdService
{
    Task<Guid?> GetRecruiterIdAsync(Guid userId, CancellationToken cancellationToken);
}