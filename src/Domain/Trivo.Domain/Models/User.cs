using Trivo.Domain.Common;

namespace Trivo.Domain.Models;

public sealed class User : BaseEntity
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Biography { get; set; }

    public bool? IsAccountConfirmed { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public string? Username { get; set; }

    public string? Location { get; set; }

    public string? ProfilePicture { get; set; }

    public string? LinkedIn { get; set; }

    public string? UserStatus { get; set; }

    public string? Position { get; set; }

    // Relationships
    public ICollection<Code>? Codes { get; set; }

    public ICollection<UserInterest>? UserInterests { get; set; }

    public ICollection<Interest> Interests { get; set; } = new List<Interest>();

    public ICollection<UserSkill>? UserSkills { get; set; }

    public ICollection<ChatUser>? ChatUsers { get; set; }

    public ICollection<Message>? SentMessages { get; set; }

    public ICollection<Message>? ReceivedMessages { get; set; }

    public ICollection<Notification>? Notifications { get; set; }

    public ICollection<Expert>? Experts { get; set; }

    public ICollection<Recruiter>? Recruiters { get; set; }

    public ICollection<Report>? Reports { get; set; }
}