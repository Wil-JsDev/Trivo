using Trivo.Domain.Common;

namespace Trivo.Domain.Models;

public sealed class Administrator : BaseEntity
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Biography { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public string? Username { get; set; }

    public string? ProfilePicture { get; set; }

    public bool? IsActive { get; set; } = true;

    public string? LinkedIn { get; set; }
    
}