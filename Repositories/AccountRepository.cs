using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Data;
using jwtauth.Models;
using Microsoft.EntityFrameworkCore;

namespace jwtauth.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly CrmDbContext crmDbContext;
        public AccountRepository(CrmDbContext crmDbContext)
        {
            this.crmDbContext = crmDbContext;
            
        }
        public async Task<Account> CreateAccountAsync(Account account)
        {
            await crmDbContext.Accounts.AddAsync(account);
            await crmDbContext.SaveChangesAsync();
            return account;
            
        }

        public async Task<Account> DeleteAcccountAsync(int id)
        {
            var deleteModel = await crmDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
            if (deleteModel != null)
            {
                crmDbContext.Remove(deleteModel);
                await crmDbContext.SaveChangesAsync();
            } 

            return deleteModel;
        }

        public async Task<Account> GetAccountById(int id)
        {
           return await crmDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);

        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            return await crmDbContext.Accounts.ToListAsync();
        }

        public async Task<Account> UpdateAccountAsync(int id, Account account)
        {
            var UpdateMoldes = await crmDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
            if (UpdateMoldes == null)
            {
                return null;
            }

            await crmDbContext.SaveChangesAsync();
            return UpdateMoldes;
        }
    }
}