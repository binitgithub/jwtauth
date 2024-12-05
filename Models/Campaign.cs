using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwtauth.Models
{
    public class Campaign
    {
    public int CampaignId { get; set; }
    public string CampaignName { get; set; }
    public string Type { get; set; } // e.g., Email, Social Media
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Budget { get; set; }
    public decimal ActualCost { get; set; }
    }
}