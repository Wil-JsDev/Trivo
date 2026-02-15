using Microsoft.EntityFrameworkCore;
using Trivo.Application.Interfaces.Services;
using Trivo.Domain.Models;
using Trivo.Infrastructure.Persistence.Context;

namespace Trivo.Infrastructure.Persistence.Services;

public class GetExpertIdService(TrivoContext context) : IGetExpertIdService
{
    public async Task<Guid?> GetExpertIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var expert = await context.Set<Expert>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.UserId == userId, cancellationToken);

        return expert?.Id;
    }
}