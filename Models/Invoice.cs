using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwtauth.Models
{
    public class Invoice
    {
    public int InvoiceId { get; set; }
    public string InvoiceNumber { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime InvoiceDate { get; set; }
    public DateTime DueDate { get; set; }

    // Relationships
    public int? LeadId { get; set; }
    public Lead Lead { get; set; }
    }
}