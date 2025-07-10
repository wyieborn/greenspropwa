using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GreensProPWA.Shared.Entity
{
    public class IssueReport
    {
        public int Id { get; set; }

        public string SubmittedBy { get; set; } = string.Empty; // optional for now

        public string Category { get; set; } = "General"; // e.g., "Equipment", "Facility", "Other"
        [Required]
        public string Title { get; set; } = string.Empty;  // short headline like "Mower not starting"

        public string Description { get; set; } = string.Empty;  // optional details

        public string? ImageBase64 { get; set; }  // optional image (camera/photo upload)

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }

}
