using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Data;
using jwtauth.Models;
using Microsoft.EntityFrameworkCore;

namespace jwtauth.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly CrmDbContext crmDbContext;

        public EmailRepository(CrmDbContext crmDbContext)
        {
            this.crmDbContext = crmDbContext;
        }
        public async Task<Email> CreateEmailAsync(Email email)
        {
            await crmDbContext.Emails.AddAsync(email);
            await crmDbContext.SaveChangesAsync();
            return email;
        }

        public async Task<Email> DeleteEmailAsync(int id)
        {
            var  deleteEmailModel = await crmDbContext.Emails.FirstOrDefaultAsync(x => x.EmailId == id);
            if (deleteEmailModel != null)
            {
                crmDbContext.Remove(deleteEmailModel);
                await crmDbContext.SaveChangesAsync();
            } 
            return deleteEmailModel;
        }

        public async Task<List<Email>> GetAllEmailAsync()
        {
            return await crmDbContext.Emails.ToListAsync();
        }

        public async Task<Email> GetEmailByIdAsync(int id)
        {
            return await crmDbContext.Emails.FirstOrDefaultAsync(x => x.EmailId == id);
        }

        public async Task<Email> UpdateEmailAsync(int id, Email email)
        {
            var updateEmail = await crmDbContext.Emails.FirstOrDefaultAsync(x => x.EmailId == id);
            if (updateEmail ==  null)
            {
                return null;
            }
            await crmDbContext.SaveChangesAsync();
            return updateEmail;
        }
    }
}