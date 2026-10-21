using EventTicketingWebApp.Helper;
using EventTicketingWebApp.Helpers;

namespace EventTicketingWebApp.Data.Entities
{
    public class Report : CommonProps
    {
        public Guid ReportId { get; set; }
        public Guid GeneratedBy { get; set; }
        public ReportType ReportType { get; set; }
        public DateTime GenerationDate { get; set; }
        public string? FilePath { get; set; }

        // Navigation properties
        public virtual User GeneratedByUser { get; set; } = null!;
    }
}
