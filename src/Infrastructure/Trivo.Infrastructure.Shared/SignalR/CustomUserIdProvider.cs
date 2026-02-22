using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;

namespace Trivo.Infrastructure.Shared.SignalR;

public class CustomUserIdProvider : IUserIdProvider
{
    public string? GetUserId(HubConnectionContext connection)
    {
        var subject = connection.User?.FindFirst("sub")?.Value;

        if (string.IsNullOrWhiteSpace(subject))
        {
            subject = connection.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        Console.WriteLine($"🧠 UserId (from token): {subject}");

        return subject;
    }
}