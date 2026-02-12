using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Trivo.Application.Helpers;

public static class AuthenticatedUserHelper
{
    public static Guid GetUserId(this HttpContext httpContext)
    {
        var claim = httpContext.User.FindFirst(ClaimTypes.NameIdentifier) ?? httpContext.User.FindFirst("sub");

        if (claim is null || !Guid.TryParse(claim.Value, out var userId))
        {
            throw new UnauthorizedAccessException("User is not authenticated or claim is invalid.");
        }

        return userId;
    }
}