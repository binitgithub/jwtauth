using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Models;

namespace jwtauth.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetContactAsync();
        Task<Contact> GetContactByIdAsync(int id);
        Task<Contact> CreateContactAsync(Contact contact);
        Task<Contact> UpdateContactAsync(int id, Contact contact);
        Task<Contact> DeleteContactAsync(int id);
    }
}