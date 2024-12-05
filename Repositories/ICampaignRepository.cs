using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Models;

namespace jwtauth.Repositories
{
    public interface ICampaignRepository
    {
        Task<List<Campaign>> GetCampaignAsync();
        Task<Campaign> GetCampaignByIdAsync(int id);
        Task<Campaign> CreateCampaignAsync(Campaign campaign);
        Task<Campaign> UpdateCampaignAsync(int id, Campaign campaign);
        Task<Campaign> DeleteCampaignAsync(int id);

    }
}