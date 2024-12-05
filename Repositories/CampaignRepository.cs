using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Data;
using jwtauth.Models;
using Microsoft.EntityFrameworkCore;

namespace jwtauth.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly CrmDbContext crmDbContext;

        public CampaignRepository(CrmDbContext crmDbContext)
        {
            this.crmDbContext = crmDbContext;
        }
        public async Task<Campaign> CreateCampaignAsync(Campaign campaign)
        {
            await crmDbContext.Campaigns.AddAsync(campaign);
            await crmDbContext.SaveChangesAsync();
            return campaign;
        }

        public async Task<Campaign> DeleteCampaignAsync(int id)
        {
            var deleteModelcam = await crmDbContext.Campaigns.FirstOrDefaultAsync(x => x.CampaignId == id);
            if (deleteModelcam != null)
            {
                crmDbContext.Remove(deleteModelcam);
                await crmDbContext.SaveChangesAsync();
            }
            return deleteModelcam;
        }

        public async Task<List<Campaign>> GetCampaignAsync()
        {
            return await crmDbContext.Campaigns.ToListAsync();
        }

        public async Task<Campaign> GetCampaignByIdAsync(int id)
        {
            return await crmDbContext.Campaigns.FirstOrDefaultAsync(x => x.CampaignId == id);
        }

        public async Task<Campaign> UpdateCampaignAsync(int id, Campaign campaign)
        {
            var updateCamModels = await crmDbContext.Campaigns.FirstOrDefaultAsync(x => x.CampaignId == id);
            if (updateCamModels == null)
            {
                return null;
            } 
            await crmDbContext.SaveChangesAsync();
            return updateCamModels;
        }
    }
}