using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Models;
using jwtauth.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace jwtauth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly EInvoiceRepository eInvoiceRepository;

        public InvoiceController(EInvoiceRepository eInvoiceRepository)
        {
            this.eInvoiceRepository = eInvoiceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoice()
        {
            var GetInvoiceModels = await eInvoiceRepository.GetInvoiceAsync();
            return Ok(GetInvoiceModels);
        }
        [HttpGet ("{id:int}")]
        public async Task<IActionResult> GetByIdInvoice([FromRoute] int id)
        {
            var InvoiceGetByIdModels = await eInvoiceRepository.GetInvoiceById(id);
            if (InvoiceGetByIdModels == null)
            {
                return NotFound();
            }
            return Ok(InvoiceGetByIdModels);
        }
        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
        {
            var createInvoiceModels = await eInvoiceRepository.CreateInvoiceAsync(invoice);
            return CreatedAtAction(nameof(GetByIdInvoice), new {createInvoiceModels.InvoiceId}, createInvoiceModels);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateInvoice([FromRoute] int id, [FromBody] Invoice invoice)
        {
            var upddateInvoiceModel = await eInvoiceRepository.UpdateInvoiceAsync(id, invoice);
            if (upddateInvoiceModel == null)
            {
                return NotFound();
            }

            return Ok(upddateInvoiceModel);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteInvoice([FromRoute] int id)
        {
            var DeleteInvoiceModel = await eInvoiceRepository.DeleteInvoiceAsync(id);
            if (DeleteInvoiceModel == null)
            {
                return NotFound();
            }
            return Ok(DeleteInvoiceModel);
        }
    }
}