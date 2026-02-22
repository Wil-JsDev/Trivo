using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trivo.Domain.Models;

namespace Trivo.Infrastructure.Persistence.Configurations;

public class ChatUserConfig : IEntityTypeConfiguration<ChatUser>
{
    public void Configure(EntityTypeBuilder<ChatUser> builder)
    {
        // Table Mapping
        builder.ToTable("ChatUser");

        // Composite Primary Key
        builder.HasKey(cu => new { cu.ChatId, cu.UserId });

        // Properties
        builder.Property(cu => cu.ChatId)
            .HasColumnName("FKChatId")
            .IsRequired();

        builder.Property(cu => cu.UserId)
            .HasColumnName("FKUserId")
            .IsRequired();

        builder.Property(cu => cu.JoinedAt)
            .IsRequired();

        builder.Property(cu => cu.LeftAt)
            .IsRequired(false);

        builder.Property(cu => cu.ChatName)
            .HasMaxLength(100)
            .IsRequired();
    }
}