using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwtauth.Models
{
    public class Activity
    {
    public int ActivityId { get; set; }
    public string Type { get; set; } // e.g., Call, Meeting, Email
    public string Subject { get; set; }
    public DateTime ActivityDate { get; set; }

    // Relationships
    public int? LeadId { get; set; }
    public Lead Lead { get; set; }
    }
}