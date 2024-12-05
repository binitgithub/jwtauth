using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwtauth.Models
{
    public class Quote
    {
    public int QuoteId { get; set; }
    public string QuoteNumber { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime ValidUntil { get; set; }

    // Relationships
    public int? LeadId { get; set; }
    public Lead Lead { get; set; }
    }
}