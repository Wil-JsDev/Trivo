using Trivo.Domain.Models;

namespace Trivo.Application.Helpers;

public static class UserHelper
{
    public static string FullName(this User user)
    {
        return $"{user.FirstName} {user.LastName}".Trim();
    }
}