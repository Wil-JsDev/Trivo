using Microsoft.EntityFrameworkCore;
using Trivo.Application.Interfaces.Services;
using Trivo.Domain.Enums;
using Trivo.Domain.Models;
using Trivo.Infrastructure.Persistence.Context;

namespace Trivo.Infrastructure.Persistence.Services;

public class UserRoleService(TrivoContext context) : IUserRoleService
{
    public async Task<IList<Roles>> GetRolesAsync(Guid userId, CancellationToken cancellationToken)
    {
        var roles = new List<Roles>();

        // Check if user is a Recruiter
        var isRecruiter = await context.Set<Recruiter>()
            .AsNoTracking()
            .AnyAsync(r => r.UserId == userId, cancellationToken);

        if (isRecruiter)
            roles.Add(Roles.Recruiter);

        // Check if user is an Expert
        var isExpert = await context.Set<Expert>()
            .AsNoTracking()
            .AnyAsync(e => e.UserId == userId, cancellationToken);

        if (isExpert)
            roles.Add(Roles.Expert);

        // Get user email to verify if they are an Administrator
        var email = await context.Set<User>()
            .AsNoTracking()
            .Where(u => u.Id == userId)
            .Select(u => u.Email)
            .FirstOrDefaultAsync(cancellationToken);

        if (string.IsNullOrWhiteSpace(email)) return roles;

        // Check if user is an Administrator
        var isAdmin = await context.Set<Administrator>()
            .AsNoTracking()
            .AnyAsync(a => a.Email == email, cancellationToken);

        if (isAdmin)
            roles.Add(Roles.Administrator);

        return roles;
    }
}