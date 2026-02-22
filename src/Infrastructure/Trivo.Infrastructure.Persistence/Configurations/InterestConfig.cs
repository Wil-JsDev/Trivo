using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trivo.Domain.Models;

namespace Trivo.Infrastructure.Persistence.Configurations;

public class InterestConfig : IEntityTypeConfiguration<Interest>
{
    public void Configure(EntityTypeBuilder<Interest> builder)
    {
        // Table Mapping
        builder.ToTable("Interest");

        // Primary Key
        builder.HasKey(e => e.Id)
            .HasName("PKInterestId");

        // Properties
        builder.Property(e => e.Id)
            .HasColumnName("PKInterestId")
            .IsRequired();

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .IsRequired(false);

        // Foreign Key Column Names
        builder.Property(e => e.CategoryId)
            .HasColumnName("FKCategoryId")
            .IsRequired();

        builder.Property(e => e.CreatedBy)
            .HasColumnName("FKCreatedById")
            .IsRequired();
    }
}