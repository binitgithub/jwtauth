using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Models;

namespace jwtauth.Repositories
{
    public interface EInvoiceRepository
    {
        Task<List<Invoice>> GetInvoiceAsync();
        Task<Invoice> GetInvoiceById(int id);
        Task<Invoice> CreateInvoiceAsync(Invoice invoice);
        Task<Invoice> UpdateInvoiceAsync(int id, Invoice invoice);
        Task<Invoice> DeleteInvoiceAsync(int id);
    }
}