using Microsoft.EntityFrameworkCore;
using Trivo.Application.Interfaces.Repository.Account;
using Trivo.Domain.Enums;
using Trivo.Domain.Models;
using Trivo.Infrastructure.Persistence.Base;
using Trivo.Infrastructure.Persistence.Context;

namespace Trivo.Infrastructure.Persistence.Repository.Account;

public class UserRepository(TrivoContext context) :
    GenericRepository<User>(context),
    IUserRepository
{
    public async Task<bool> IsAccountConfirmedAsync(Guid id, CancellationToken cancellationToken) =>
        await ValidateAsync(u => u.Id == id && (bool)u.IsAccountConfirmed!, cancellationToken);

    public async Task<bool> IsUsernameInUseAsync(string username, Guid userId, CancellationToken cancellationToken) =>
        await ValidateAsync(u => u.Username == username && u.Id != userId, cancellationToken);

    public async Task<string?> GetStatusAsync(Guid userId, CancellationToken cancellationToken) =>
        await Context.Set<User>()
            .AsNoTracking()
            .Where(u => u.Id == userId)
            .Select(u => u.UserStatus)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken) =>
        (await Context.Set<User>()
            .AsNoTracking()
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync(cancellationToken))!;

    public async Task<User> GetByUsernameAsync(string username, CancellationToken cancellationToken) =>
        (await Context.Set<User>()
            .AsNoTracking()
            .Where(u => u.Username == username)
            .FirstOrDefaultAsync(cancellationToken))!;

    public async Task<List<Guid?>> GetSkillsAsync(Guid userId, CancellationToken cancellationToken) =>
        await Context.Set<UserSkill>()
            .Where(uh => uh.UserId == userId)
            .Select(uh => uh.SkillId)
            .ToListAsync(cancellationToken);

    public async Task<List<Guid?>> GetInterestsAsync(Guid userId, CancellationToken cancellationToken) =>
        await Context.Set<UserInterest>()
            .Where(ui => ui.UserId == userId)
            .Select(ui => ui.InterestId)
            .ToListAsync(cancellationToken);

    public async Task<bool> IsEmailInUseAsync(string email, Guid excludeUserId, CancellationToken cancellationToken) =>
        await ValidateAsync(u => u.Email == email && u.Id != excludeUserId, cancellationToken);

    public async Task UpdatePasswordAsync(User user, string newHashedPassword, CancellationToken cancellationToken)
    {
        user.PasswordHash = newHashedPassword;
        Context.Set<User>().Update(user);
        await Task.CompletedTask;
    }

    public async Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken) =>
        await ValidateAsync(u => u.Email == email, cancellationToken);

    public async Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken) =>
        await ValidateAsync(u => u.Username == username, cancellationToken);

    public async Task<User> GetDetailsByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return (await Context.Set<User>()
            .AsNoTracking()
            .Where(u => u.Id == userId)
            .Select(u => new User
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Location = u.Location,
                Biography = u.Biography,
                ProfilePicture = u.ProfilePicture,
                Position = u.Position,
                UserSkills = u.UserSkills!
                    .Select(uh => new UserSkill
                    {
                        SkillId = uh.SkillId,
                        Skill = new Skill
                        {
                            SkillId = uh.SkillId,
                            Name = uh.Skill!.Name
                        }
                    }).ToList(),
                UserInterests = u.UserInterests!
                    .Select(ui => new UserInterest
                    {
                        InterestId = ui.InterestId,
                        Interest = new Interest
                        {
                            Name = ui.Interest!.Name
                        }
                    }).ToList()
            })
            .AsSingleQuery()
            .FirstOrDefaultAsync(cancellationToken))!;
    }

    public async Task<IEnumerable<User>> GetByInterestsAndSkillsAsync(
        List<Guid>? interestIds,
        List<Guid>? skillIds,
        CancellationToken cancellationToken)
    {
        var userIds = new HashSet<Guid>();

        if (interestIds != null && interestIds.Any())
        {
            var usersWithInterests = await Context.Set<UserInterest>()
                .AsNoTracking()
                .Where(ui => interestIds.Contains((Guid)ui.InterestId!))
                .Select(ui => ui.UserId)
                .Distinct()
                .ToListAsync(cancellationToken);

            foreach (var id in usersWithInterests) userIds.Add((Guid)id!);
        }

        if (skillIds != null && skillIds.Any())
        {
            var usersWithSkills = await Context.Set<UserSkill>()
                .AsNoTracking()
                .Where(uh => skillIds.Contains((Guid)uh.SkillId!))
                .Select(uh => uh.UserId)
                .Distinct()
                .ToListAsync(cancellationToken);

            foreach (var id in usersWithSkills) userIds.Add((Guid)id!);
        }

        if (userIds.Count == 0) return [];

        return await Context.Set<User>()
            .AsNoTracking()
            .Where(u => userIds.Contains(u.Id))
            .Include(u => u.UserInterests)!.ThenInclude(ui => ui.Interest)
            .Include(u => u.UserSkills)!.ThenInclude(uh => uh.Skill)
            .Include(u => u.Recruiters)
            .Include(u => u.Experts)
            .ToListAsync(cancellationToken);
    }

    public async Task<User?> GetUserWithInterestsAndSkillsAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await Context.Set<User>()
            .AsNoTracking()
            .Include(u => u.UserInterests)!.ThenInclude(ui => ui.Interest)
            .Include(u => u.UserSkills)!.ThenInclude(uh => uh.Skill)
            .AsSplitQuery()
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
    }

    public async Task<IEnumerable<User>> GetAllWithInterestsAndSkillsAsync(CancellationToken cancellationToken)
    {
        return await Context.Set<User>()
            .AsNoTracking()
            .Include(u => u.UserInterests)!.ThenInclude(ui => ui.Interest)
            .Include(u => u.UserSkills)!.ThenInclude(uh => uh.Skill)
            .AsSplitQuery()
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<UserInterest>> GetInterestsByUserIdAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        return await Context.Set<UserInterest>()
            .Where(ui => ui.UserId == userId)
            .Include(ui => ui.Interest)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<UserSkill>> GetSkillsByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await Context.Set<UserSkill>()
            .Where(uh => uh.UserId == userId)
            .Include(uh => uh.Skill)
            .ToListAsync(cancellationToken);
    }

    public async Task<string> GetUserRoleAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await Context.Set<User>()
            .AsNoTracking()
            .Include(u => u.Experts)
            .Include(u => u.Recruiters)
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

        if (user == null) return "No Role";

        if (user.Experts?.Any() == true) return Roles.Expert.ToString();
        if (user.Recruiters?.Any() == true) return Roles.Recruiter.ToString();

        return "No Role";
    }

    public async Task<User?> GetExpertAndRecruiterRelationshipsByUserIdAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        return await Context.Set<User>()
            .AsNoTracking()
            .Include(u => u.Recruiters)
            .Include(u => u.Experts)
            .Include(u => u.UserSkills)!.ThenInclude(uh => uh.Skill)
            .Include(u => u.UserInterests)!.ThenInclude(ui => ui.Interest)
            .FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
    }

    public async Task<User?> GetByIdWithRelationshipsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Context.Set<User>()
            .AsNoTracking()
            .Include(u => u.UserInterests)!.ThenInclude(ui => ui.Interest)
            .Include(u => u.UserSkills)!.ThenInclude(uh => uh.Skill)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<User>> GetTargetUsersAsync(Guid currentUserId, string role,
        CancellationToken cancellationToken)
    {
        var query = Context.Set<User>()
            .AsNoTracking()
            .Include(u => u.UserInterests)!.ThenInclude(ui => ui.Interest)
            .Include(u => u.UserSkills)!.ThenInclude(uh => uh.Skill)
            .Where(u => u.Id != currentUserId);

        if (role == Roles.Recruiter.ToString())
        {
            query = query.Where(u => u.Experts != null && u.Experts.Any());
        }
        else if (role == Roles.Expert.ToString())
        {
            query = query.Where(u => u.Recruiters != null && u.Recruiters.Any());
        }

        return await query.AsSplitQuery().ToListAsync(cancellationToken);
    }
}