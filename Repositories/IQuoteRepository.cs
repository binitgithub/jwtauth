using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Models;

namespace jwtauth.Repositories
{
    public interface IQuoteRepository
    {
        Task<List<Quote>> GetQuoteAsync();
        Task<Quote> GetQuoteByIdAsync(int id);
        Task<Quote> CreateQuoteAsync(Quote quote);
        Task<Quote> UpdateQuoteAsync(int id, Quote quote);
        Task<Quote> DeleteQuoteAsync(int id);
    }
}