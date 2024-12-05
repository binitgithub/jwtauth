using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Data;
using jwtauth.Models;
using Microsoft.EntityFrameworkCore;

namespace jwtauth.Repositories
{
    public class InvoiceRepository : EInvoiceRepository
    {
        private readonly CrmDbContext crmDbContext;

        public InvoiceRepository(CrmDbContext crmDbContext)
        {
            this.crmDbContext = crmDbContext;
        }
        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
        {
            await crmDbContext.Invoices.AddAsync(invoice);
            await crmDbContext.SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice> DeleteInvoiceAsync(int id)
        {
            var deleteInvoiceMode = await crmDbContext.Invoices.FirstOrDefaultAsync(x => x.InvoiceId == id);
            if (deleteInvoiceMode != null)
            {
                crmDbContext.Remove(deleteInvoiceMode);
                await crmDbContext.SaveChangesAsync();
            }
            return deleteInvoiceMode;
        }

        public async Task<List<Invoice>> GetInvoiceAsync()
        {
            return await crmDbContext.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetInvoiceById(int id)
        {
            return await crmDbContext.Invoices.FirstOrDefaultAsync(x => x.InvoiceId == id);
        }

        public async Task<Invoice> UpdateInvoiceAsync(int id, Invoice invoice)
        {
            var updateInvoice = await crmDbContext.Invoices.FirstOrDefaultAsync(x => x.InvoiceId == id);
            if (updateInvoice == null)
            {
                return null;
            }

            await crmDbContext.SaveChangesAsync();
            return updateInvoice;
        }
    }
}