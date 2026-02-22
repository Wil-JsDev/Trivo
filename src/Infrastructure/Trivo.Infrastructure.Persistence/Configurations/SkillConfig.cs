using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trivo.Domain.Models;

namespace Trivo.Infrastructure.Persistence.Configurations;

public class SkillConfig : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        // Table Mapping
        builder.ToTable("Skill");

        // Primary Key
        builder.HasKey(s => s.SkillId)
            .HasName("PKSkillId");

        // Properties
        builder.Property(s => s.SkillId)
            .HasColumnName("PKSkillId")
            .IsRequired();

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(s => s.RegisteredAt)
            .IsRequired();
    }
}