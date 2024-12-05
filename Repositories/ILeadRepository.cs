using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Models;

namespace jwtauth.Repositories
{
    public interface ILeadRepository
    {
        Task<List<Lead>> GetAllLeadsAsync();
        Task<Lead> GetLeadByIdAsync(int id);
        Task<Lead> CreateLeadAync(Lead lead);
        Task<Lead> UpdateLeadAsync(int id, Lead lead);
        Task<Lead> DeleteLeadAsync(int id);

    }
}