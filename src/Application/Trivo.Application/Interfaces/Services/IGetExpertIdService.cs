namespace Trivo.Application.Interfaces.Services;

public interface IGetExpertIdService
{
    Task<Guid?> GetExpertIdAsync(Guid userId, CancellationToken cancellationToken);
}