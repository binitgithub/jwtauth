using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Data;
using jwtauth.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace jwtauth.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly CrmDbContext crmDbContext;
        public LeadRepository(CrmDbContext crmDbContext)
        {
            this.crmDbContext = crmDbContext;
            
        }
        public async Task<Lead> CreateLeadAync(Lead lead)
        {
            await crmDbContext.Leads.AddAsync(lead);
            await crmDbContext.SaveChangesAsync();
            return lead;
        }

        public async Task<Lead> DeleteLeadAsync(int id)
        {
            var deleteLead = await crmDbContext.Leads.FirstOrDefaultAsync(x => x.LeadId == id);
            if (deleteLead != null)
            {
                crmDbContext.Remove(deleteLead);
                await crmDbContext.SaveChangesAsync();

            }

            return deleteLead;
        }

        public async Task<List<Lead>> GetAllLeadsAsync()
        {
            return await crmDbContext.Leads.ToListAsync();
        }

        public async Task<Lead> GetLeadByIdAsync(int id)
        {
            return await crmDbContext.Leads.FirstOrDefaultAsync(x => x.LeadId == id);
        }

        public async Task<Lead> UpdateLeadAsync(int id, Lead lead)
        {
            var updateLead = await crmDbContext.Leads.FirstOrDefaultAsync(x => x.LeadId == id);
            if (updateLead == null)
            {
                return null;
            }

            await crmDbContext.SaveChangesAsync();
            return updateLead;
        }
    }
}