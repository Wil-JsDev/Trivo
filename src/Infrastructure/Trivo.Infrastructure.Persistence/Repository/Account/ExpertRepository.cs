using Microsoft.EntityFrameworkCore;
using Trivo.Application.Interfaces.Repository.Account;
using Trivo.Domain.Models;
using Trivo.Infrastructure.Persistence.Base;
using Trivo.Infrastructure.Persistence.Context;

namespace Trivo.Infrastructure.Persistence.Repository.Account;

public class ExpertRepository(TrivoContext context) : GenericRepository<Expert>(context), IExpertRepository
{
    public async Task<IEnumerable<Expert>> FilterExpertsAsync(
        List<Guid> skillIds,
        List<Guid> interestIds,
        CancellationToken cancellationToken
    )
    {
        return await Context.Set<Expert>()
            .AsNoTracking()
            .Include(e => e.User)
            .ThenInclude(u => u!.UserSkills)
            .Include(e => e.User)
            .ThenInclude(u => u!.UserInterests)
            .AsSplitQuery()
            .Where(e =>
                e.User != null &&
                (skillIds.Count == 0 ||
                 e.User.UserSkills!
                     .Any(us => skillIds.Contains((Guid)us.SkillId!))) &&
                (interestIds.Count == 0 ||
                 e.User.UserInterests!
                     .Any(ui => interestIds.Contains((Guid)ui.InterestId!))))
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> IsUserExpertAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await ValidateAsync(x => x.UserId == userId, cancellationToken);
    }

    public async Task<Expert?> GetExpertDetailsAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await Context.Set<Expert>()
            .AsNoTracking()
            .Include(e => e.User)
            .ThenInclude(u => u!.UserSkills)!
            .ThenInclude(us => us.Skill)
            .Include(e => e.User)
            .ThenInclude(u => u!.UserInterests)!
            .ThenInclude(ui => ui.Interest)
            .FirstOrDefaultAsync(e => e.UserId == userId, cancellationToken);
    }

    /// <summary>
    /// Overrides the base GetByIdAsync to include User, Skills, and Interests.
    /// </summary>
    public new async Task<Expert?> GetByIdAsync(Guid expertId, CancellationToken cancellationToken)
    {
        return await Context.Set<Expert>()
            .Include(e => e.User)
            .ThenInclude(u => u!.UserSkills)!
            .ThenInclude(us => us.Skill)
            .Include(e => e.User)
            .ThenInclude(u => u!.UserInterests)!
            .ThenInclude(ui => ui.Interest)
            .AsSplitQuery()
            .FirstOrDefaultAsync(e => e.Id == expertId, cancellationToken);
    }

    public async Task<Expert?> GetExpertByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await Context.Set<Expert>()
            .AsNoTracking()
            .Where(e => e.UserId == userId)
            .Include(e => e.User)
            .ThenInclude(u => u!.UserSkills)!
            .ThenInclude(us => us.Skill)
            .Include(e => e.User)
            .ThenInclude(u => u!.UserInterests)!
            .ThenInclude(ui => ui.Interest)
            .AsSplitQuery()
            .FirstOrDefaultAsync(cancellationToken);
    }
}