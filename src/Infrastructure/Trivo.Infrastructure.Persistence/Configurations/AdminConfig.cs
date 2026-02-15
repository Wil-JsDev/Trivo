using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trivo.Domain.Models;

namespace Trivo.Infrastructure.Persistence.Configurations;

public class AdministratorConfig : IEntityTypeConfiguration<Administrator>
{
    public void Configure(EntityTypeBuilder<Administrator> builder)
    {
        // Table Mapping
        builder.ToTable("Administrator");

        // Primary Key
        builder.HasKey(a => a.Id)
            .HasName("PKAdministratorId");

        // Properties
        builder.Property(a => a.Id)
            .HasColumnName("PKAdministratorId")
            .IsRequired();

        builder.Property(a => a.FirstName)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(a => a.LastName)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(a => a.Biography)
            .IsRequired()
            .HasColumnType("text");

        builder.Property(a => a.Email)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.HasIndex(a => a.Email)
            .IsUnique()
            .HasDatabaseName("UQAdministratorEmail");

        builder.Property(a => a.PasswordHash)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(a => a.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(a => a.Username)
            .IsUnique()
            .HasDatabaseName("UQAdministratorUsername");

        builder.Property(a => a.ProfilePicture)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(a => a.LinkedIn)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(a => a.CreatedAt)
            .IsRequired();

        builder.Property(a => a.UpdatedAt)
            .IsRequired(false);

        builder.Property(a => a.IsActive)
            .IsRequired();
    }
}