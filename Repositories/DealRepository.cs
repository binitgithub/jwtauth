using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Data;
using jwtauth.Models;
using Microsoft.EntityFrameworkCore;

namespace jwtauth.Repositories
{
    public class DealRepository : IDealRepository
    {
        private readonly CrmDbContext crmDbContext;

        public DealRepository(CrmDbContext crmDbContext)
        {
            this.crmDbContext = crmDbContext;
        }
        public async Task<Deal> CreateDealAsync(Deal deal)
        {
            await crmDbContext.Deals.AddAsync(deal);
            await crmDbContext.SaveChangesAsync();
            return deal;

        }

        public async Task<Deal> DeleteAsync(int id)
        {
            var deleteModel = await crmDbContext.Deals.FirstOrDefaultAsync(x => x.DealId == id);
            if (deleteModel != null)
            {
                crmDbContext.Remove(deleteModel);
                await crmDbContext.SaveChangesAsync();
            }
            return deleteModel;
        }

        public async Task<List<Deal>> GetDealAsync()
        {
            return await crmDbContext.Deals.ToListAsync();
        }

        public async Task<Deal> GetDealByIdAsync(int id)
        {
            return await crmDbContext.Deals.FirstOrDefaultAsync(x => x.DealId == id);
        }

        public async Task<Deal> UpdateDealAsync(int id, Deal deal)
        {
            var updateModel = await crmDbContext.Deals.FirstOrDefaultAsync(x => x.DealId == id);
            if (updateModel == null)
            {
                return null;
            }

            await crmDbContext.SaveChangesAsync();
            return updateModel;

        }
    }
}