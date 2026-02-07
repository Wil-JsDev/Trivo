namespace Trivo.Domain.Models;

public sealed class Report
{
    public Guid? ReportId { get; set; }

    public Guid? ReportedById { get; set; }

    public Guid? MessageId { get; set; }

    public string? ReportStatus { get; set; }

    public string? Note { get; set; }

    public Message? Message { get; set; }

    public User? User { get; set; }
}