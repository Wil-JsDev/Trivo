using Microsoft.EntityFrameworkCore;
using Trivo.Application.Interfaces.Repository;
using Trivo.Domain.Enums;
using Trivo.Domain.Models;
using Trivo.Infrastructure.Persistence.Base;
using Trivo.Infrastructure.Persistence.Context;

namespace Trivo.Infrastructure.Persistence.Repository;

public class MatchRepository(TrivoContext context) : GenericRepository<Match>(context), IMatchRepository
{
    public async Task<Match?> GetAsync(Guid expertId, Guid recruiterId, CancellationToken cancellationToken)
    {
        return await Context.Set<Match>()
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ExpertId == expertId && m.RecruiterId == recruiterId, cancellationToken);
    }

    public async Task<bool> ExistsAsync(Guid expertId, Guid recruiterId, CancellationToken cancellationToken)
    {
        return await ValidateAsync(x => x.ExpertId == expertId && x.RecruiterId == recruiterId, cancellationToken);
    }

    public async Task<IEnumerable<Match>> GetAsExpertAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await Context.Set<Match>()
            .AsNoTracking()
            .Include(m => m.Expert)
            .ThenInclude(e => e!.User)
            .ThenInclude(u => u!.UserSkills)!
            .ThenInclude(us => us.Skill)
            .Include(m => m.Expert)
            .ThenInclude(e => e!.User)
            .ThenInclude(u => u!.UserInterests)!
            .ThenInclude(ui => ui.Interest)
            .Include(m => m.Recruiter)
            .ThenInclude(r => r!.User)
            .ThenInclude(u => u!.UserSkills)!
            .ThenInclude(us => us.Skill)
            .Include(m => m.Recruiter)
            .ThenInclude(r => r!.User)
            .ThenInclude(u => u!.UserInterests)!
            .ThenInclude(ui => ui.Interest)
            .AsSplitQuery()
            .Where(m => m.Expert!.UserId == userId)
            .Where(m => m.MatchStatus == MatchStatus.Pending.ToString())
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Match>> GetAsRecruiterAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await Context.Set<Match>()
            .AsNoTracking()
            .Include(m => m.Recruiter)
            .ThenInclude(r => r!.User)
            .ThenInclude(u => u!.UserSkills)!
            .ThenInclude(us => us.Skill)
            .Include(m => m.Recruiter)
            .ThenInclude(r => r!.User)
            .ThenInclude(u => u!.UserInterests)!
            .ThenInclude(ui => ui.Interest)
            .Include(m => m.Expert)
            .ThenInclude(ex => ex!.User)
            .ThenInclude(u => u!.UserSkills)!
            .ThenInclude(us => us.Skill)
            .Include(m => m.Expert)
            .ThenInclude(ex => ex!.User)
            .ThenInclude(u => u!.UserInterests)!
            .ThenInclude(ui => ui.Interest)
            .AsSplitQuery()
            .Where(m => m.Recruiter!.UserId == userId)
            .Where(m => m.MatchStatus == MatchStatus.Pending.ToString())
            .ToListAsync(cancellationToken);
    }

    public async Task<Match?> GetByIdAsync(Guid matchId, CancellationToken cancellationToken)
    {
        return await Context.Set<Match>()
            .AsNoTracking()
            .Include(m => m.Expert)
            .ThenInclude(e => e!.User)
            .ThenInclude(u => u!.UserSkills)!
            .ThenInclude(us => us.Skill)
            .Include(m => m.Expert)
            .ThenInclude(e => e!.User)
            .ThenInclude(u => u!.UserInterests)!
            .ThenInclude(ui => ui.Interest)
            .Include(m => m.Recruiter)
            .ThenInclude(r => r!.User)
            .ThenInclude(u => u!.UserSkills)!
            .ThenInclude(us => us.Skill)
            .Include(m => m.Recruiter)
            .ThenInclude(r => r!.User)
            .ThenInclude(u => u!.UserInterests)!
            .ThenInclude(ui => ui.Interest)
            .AsSplitQuery()
            .FirstOrDefaultAsync(m => m.Id == matchId, cancellationToken);
    }

    public async Task UpdateStatusAsync(Guid matchId,
        MatchUpdateStatus? status, CancellationToken cancellationToken)
    {
        var match = await Context.Set<Match>()
            .FirstOrDefaultAsync(m => m.Id == matchId, cancellationToken);

        if (match != null)
        {
            match.MatchStatus = status.ToString()!;
            match.ExpertStatus = status.ToString()!;
            match.RecruiterStatus = status.ToString()!;
            match.UpdatedAt = DateTime.UtcNow;

            Context.Update(match);
        }

        await Task.CompletedTask;
    }
}