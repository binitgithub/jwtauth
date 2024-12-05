using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Models;

namespace jwtauth.Repositories
{
    public interface IEmailRepository
    {
        Task<List<Email>> GetAllEmailAsync();
        Task<Email> GetEmailByIdAsync(int id);
        Task<Email> CreateEmailAsync(Email email);
        Task<Email> UpdateEmailAsync(int id, Email email);
        Task<Email> DeleteEmailAsync(int id);
    }
}