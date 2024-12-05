using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwtauth.Models
{
    public class Lead
    {
    public int? LeadId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Status { get; set; } // e.g., New, Qualified, Converted
    public DateTime? CreatedDate { get; set; }
    public DateTime? ConvertedDate { get; set; }

    // Relationships
    public int? AccountId { get; set; }
    public Account Account { get; set; }

    public ICollection<AppTask> AppTasks { get; set; }
    public ICollection<Activity> Activities { get; set; }
    public ICollection<Email> Emails { get; set; }
    public ICollection<Quote> Quotes { get; set; }
    public ICollection<Invoice> Invoices { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public ICollection<Deal> Deals { get; set; }
    }
}