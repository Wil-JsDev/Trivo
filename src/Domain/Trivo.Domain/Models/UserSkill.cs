namespace Trivo.Domain.Models;

public sealed class UserSkill
{
    public Guid? UserId { get; set; }

    public Guid? SkillId { get; set; }

    public User? User { get; set; }

    public Skill? Skill { get; set; }
}