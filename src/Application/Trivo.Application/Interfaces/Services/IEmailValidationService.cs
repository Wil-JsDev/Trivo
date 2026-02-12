using Trivo.Application.Utils;

namespace Trivo.Application.Interfaces.Services;

public interface IEmailValidationService
{
    Task<ResultT<bool>> ValidateEmailAsync(string email, CancellationToken cancellationToken);
}