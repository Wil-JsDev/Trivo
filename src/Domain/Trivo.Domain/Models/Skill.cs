namespace Trivo.Domain.Models;

public sealed class Skill
{
    public Guid? SkillId { get; set; }

    public string? Name { get; set; }

    public DateTime? RegisteredAt { get; set; } = DateTime.UtcNow;

    public ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
}