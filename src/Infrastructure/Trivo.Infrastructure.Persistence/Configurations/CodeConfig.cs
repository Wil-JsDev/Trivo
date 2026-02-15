using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trivo.Domain.Models;

namespace Trivo.Infrastructure.Persistence.Configurations;

public class CodeConfig : IEntityTypeConfiguration<Code>
{
    public void Configure(EntityTypeBuilder<Code> builder)
    {
        // Table Mapping
        builder.ToTable("Code");

        // Primary Key
        builder.HasKey(c => c.CodeId)
            .HasName("PKCodeId");

        // Properties
        builder.Property(c => c.CodeId)
            .HasColumnName("PKCodeId")
            .IsRequired();

        builder.Property(c => c.Value)
            .IsRequired()
            .HasColumnType("text");

        builder.Property(c => c.Type)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(c => c.IsUsed)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(c => c.ExpiresAt)
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .IsRequired();

        builder.Property(c => c.IsRevoked)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(c => c.RefreshCode)
            .IsRequired(false)
            .HasDefaultValue(false);

        // Foreign Key Column Name
        builder.Property(c => c.UserId)
            .HasColumnName("FKUserId")
            .IsRequired();
    }
}