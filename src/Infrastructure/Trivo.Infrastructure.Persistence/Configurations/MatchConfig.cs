using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trivo.Domain.Models;

namespace Trivo.Infrastructure.Persistence.Configurations;

public class MatchConfig : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        // Table Mapping
        builder.ToTable("Match");

        // Primary Key
        builder.HasKey(m => m.Id)
            .HasName("PKMatchId");

        // Properties
        builder.Property(m => m.Id)
            .HasColumnName("PKMatchId")
            .IsRequired();

        builder.Property(m => m.CreatedAt)
            .IsRequired();

        builder.Property(m => m.UpdatedAt)
            .IsRequired(false);

        builder.Property(m => m.MatchStatus)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(m => m.ExpertStatus)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(m => m.RecruiterStatus)
            .IsRequired()
            .HasColumnType("varchar(50)");
            
        // Foreign Key Column Names (as established in the Context)
        builder.Property(m => m.ExpertId)
            .HasColumnName("FKExpertId")
            .IsRequired();

        builder.Property(m => m.RecruiterId)
            .HasColumnName("FKRecruiterId")
            .IsRequired();
    }
}