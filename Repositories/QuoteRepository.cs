using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Data;
using jwtauth.Models;
using Microsoft.EntityFrameworkCore;

namespace jwtauth.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly CrmDbContext crmDbContext;

        public QuoteRepository(CrmDbContext crmDbContext)
        {
            this.crmDbContext = crmDbContext;
        }
        public async Task<Quote> CreateQuoteAsync(Quote quote)
        {
            await crmDbContext.Quotes.AddAsync(quote);
            await crmDbContext.SaveChangesAsync();
            return quote;
        }

        public async Task<Quote> DeleteQuoteAsync(int id)
        {
            var deleteQuote = await crmDbContext.Quotes.FirstOrDefaultAsync(x => x.QuoteId == id);
            if (deleteQuote != null)
            {
                crmDbContext.Remove(deleteQuote);
                await crmDbContext.SaveChangesAsync();
            }

            return deleteQuote;
        }

        public async Task<List<Quote>> GetQuoteAsync()
        {
            return await crmDbContext.Quotes.ToListAsync();
        }

        public async Task<Quote> GetQuoteByIdAsync(int id)
        {
            return await crmDbContext.Quotes.FirstOrDefaultAsync(x => x.QuoteId == id);
        }

        public async Task<Quote> UpdateQuoteAsync(int id, Quote quote)
        {
            var updateQuoteModels = await crmDbContext.Quotes.FirstOrDefaultAsync(x => x.QuoteId == id);
            if (updateQuoteModels == null)
            {
                return null;
            }

            await crmDbContext.SaveChangesAsync();
            return updateQuoteModels;
        }
    }
}