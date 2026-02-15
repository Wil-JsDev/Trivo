using Microsoft.EntityFrameworkCore;
using Trivo.Application.Interfaces.Repository.Account;
using Trivo.Domain.Models;
using Trivo.Infrastructure.Persistence.Base;
using Trivo.Infrastructure.Persistence.Context;

namespace Trivo.Infrastructure.Persistence.Repository.Account;

public class CodeRepository(TrivoContext context) : GenericRepository<Code>(context), ICodeRepository
{
    public async Task CreateCodeAsync(Code code, CancellationToken cancellationToken)
    {
        await Context.Set<Code>().AddAsync(code, cancellationToken);
    }

    public async Task<Code> GetCodeByIdAsync(Guid id, CancellationToken cancellationToken) =>
        (await Context.Set<Code>()
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CodeId == id, cancellationToken))!;

    public async Task<Code> FindCodeAsync(string code, CancellationToken cancellationToken) =>
        (await Context.Set<Code>()
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Value == code, cancellationToken))!;

    public async Task DeleteCodeAsync(Code code, CancellationToken cancellationToken)
    {
        Context.Set<Code>().Remove(code);
        await Task.CompletedTask;
    }

    public async Task<bool> CodeExistsAsync(string code, CancellationToken cancellationToken) =>
        await ValidateAsync(c => c.Value == code, cancellationToken);

    public async Task<bool> IsCodeValidAsync(string code, CancellationToken cancellationToken) =>
        await ValidateAsync(c => c.Value == code &&
                                 c.ExpiresAt > DateTime.UtcNow &&
                                 (bool)c.IsUsed!, cancellationToken);

    public async Task MarkCodeAsUsedAsync(string code, CancellationToken cancellationToken)
    {
        var userCode = await Context.Set<Code>()
            .FirstOrDefaultAsync(c => c.Value == code, cancellationToken);

        if (userCode != null)
        {
            userCode.IsUsed = true;
            Context.Set<Code>().Update(userCode);
        }
    }

    public async Task<bool> IsCodeUnusedAsync(string code, CancellationToken cancellationToken) =>
        await ValidateAsync(c => c.Value == code && (bool)(!c.IsUsed)!, cancellationToken);
}