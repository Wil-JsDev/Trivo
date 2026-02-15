using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trivo.Domain.Models;

namespace Trivo.Infrastructure.Persistence.Configurations;

public class NotificationConfig : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        // Table Mapping
        builder.ToTable("Notification");

        // Primary Key
        builder.HasKey(n => n.NotificationId)
            .HasName("PKNotificationId");

        // Properties
        builder.Property(n => n.NotificationId)
            .HasColumnName("PKNotificationId")
            .IsRequired();

        builder.Property(n => n.Type)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(n => n.Content)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(n => n.CreatedAt)
            .IsRequired();

        builder.Property(n => n.IsRead)
            .IsRequired();

        builder.Property(n => n.ReadAt)
            .IsRequired(false); // Changed to optional as notifications aren't read upon creation

        // Foreign Key Column Name
        builder.Property(n => n.UserId)
            .HasColumnName("FKUserId")
            .IsRequired();
    }
}