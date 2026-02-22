using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trivo.Domain.Models;

namespace Trivo.Infrastructure.Persistence.Configurations;

public class ReportConfig : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        // Table Mapping
        builder.ToTable("Report");

        // Primary Key
        builder.HasKey(r => r.ReportId)
            .HasName("PKReportId");

        // Properties
        builder.Property(r => r.ReportId)
            .HasColumnName("PKReportId")
            .IsRequired();

        builder.Property(r => r.Note)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(r => r.ReportStatus)
            .IsRequired()
            .HasColumnType("varchar(50)");

        // Foreign Key Column Names
        builder.Property(r => r.ReportedById)
            .HasColumnName("FKReportedById")
            .IsRequired();

        builder.Property(r => r.MessageId)
            .HasColumnName("FKMessageId")
            .IsRequired();
    }
}