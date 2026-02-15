using Microsoft.EntityFrameworkCore;
using Trivo.Application.Interfaces.Services;
using Trivo.Domain.Models;
using Trivo.Infrastructure.Persistence.Context;

namespace Trivo.Infrastructure.Persistence.Services;

public class GetRecruiterIdService(TrivoContext context) : IGetRecruiterIdService
{
    public async Task<Guid?> GetRecruiterIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var recruiter = await context.Set<Recruiter>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.UserId == userId, cancellationToken);

        return recruiter?.Id;
    }
}