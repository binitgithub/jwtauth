using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Data;
using jwtauth.Models;
using Microsoft.EntityFrameworkCore;

namespace jwtauth.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly CrmDbContext crmDbContext;

        public ContactRepository(CrmDbContext crmDbContext)
        {
            this.crmDbContext = crmDbContext;
        }
        public async Task<Contact> CreateContactAsync(Contact contact)
        {
            await crmDbContext.Contacts.AddAsync(contact);
            await crmDbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> DeleteContactAsync(int id)
        {
            var deleteConteact = await crmDbContext.Contacts.FirstOrDefaultAsync(x => x.ContactId == id);
            if (deleteConteact != null)
            {
                crmDbContext.Remove(deleteConteact);
                await crmDbContext.SaveChangesAsync();

            }

            return deleteConteact;
        }

        public async Task<List<Contact>> GetContactAsync()
        {
            return await crmDbContext.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
           return await crmDbContext.Contacts.FirstOrDefaultAsync(x => x.ContactId == id);
        }

        public async Task<Contact> UpdateContactAsync(int id, Contact contact)
        {
            var updateContact = await crmDbContext.Contacts.FirstOrDefaultAsync(x => x.ContactId == id);
            if (updateContact == null)
            {
                return null;
            }

            await crmDbContext.SaveChangesAsync();
            return updateContact;
        }
    }
}