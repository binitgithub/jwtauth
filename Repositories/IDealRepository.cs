using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Models;

namespace jwtauth.Repositories
{
    public interface IDealRepository
    {
        Task<List<Deal>> GetDealAsync();
        Task<Deal> GetDealByIdAsync(int id);
        Task<Deal> CreateDealAsync(Deal deal);
        Task<Deal> UpdateDealAsync(int id, Deal deal);
        Task<Deal> DeleteAsync(int id);
    }
}