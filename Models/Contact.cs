using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwtauth.Models
{
    public class Contact
    {
    public int ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Position { get; set; }

    // Relationships
    public int? LeadId { get; set; }
    public Lead Lead { get; set; }
    }
}