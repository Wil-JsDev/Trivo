using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trivo.Domain.Models;

namespace Trivo.Infrastructure.Persistence.Configurations;

public class ChatConfig : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        // Table Mapping
        builder.ToTable("Chat");

        // Primary Key
        builder.HasKey(c => c.Id)
            .HasName("PKChatId");

        // Properties
        builder.Property(c => c.Id)
            .HasColumnName("PKChatId")
            .IsRequired();

        builder.Property(c => c.ChatType)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(c => c.IsActive)
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .IsRequired();

        builder.Property(c => c.UpdatedAt)
            .IsRequired(false);
    }
}