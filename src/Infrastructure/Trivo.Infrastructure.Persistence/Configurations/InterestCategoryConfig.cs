using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trivo.Domain.Models;

namespace Trivo.Infrastructure.Persistence.Configurations;

public class InterestCategoryConfig : IEntityTypeConfiguration<InterestCategory>
{
    public void Configure(EntityTypeBuilder<InterestCategory> builder)
    {
        // Table Mapping
        builder.ToTable("InterestCategory");

        // Primary Key
        builder.HasKey(c => c.CategoryId)
            .HasName("PKInterestCategoryId");

        // Properties
        builder.Property(c => c.CategoryId)
            .HasColumnName("PKCategoryId")
            .IsRequired();

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}