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
    public class LeadController : ControllerBase
    {
        private readonly ILeadRepository leadRepository;

        public LeadController(ILeadRepository leadRepository)
        {
            this.leadRepository = leadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLead(){
            var domainModel = await leadRepository.GetAllLeadsAsync();
            return Ok(domainModel);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GeatLeadyById([FromRoute] int id){
            var domainModelId = await leadRepository.GetLeadByIdAsync(id);
            if (domainModelId == null)
            {
                return NotFound();
            }

            return Ok(domainModelId);

        }

        [HttpPost]
        public async Task<IActionResult> CreateLead([FromBody] Lead lead){
            var domainModelLead = await leadRepository.CreateLeadAync(lead);
            return CreatedAtAction(nameof(GeatLeadyById), new {id = domainModelLead.LeadId}, domainModelLead);

        }

        [HttpPut]
        [Route ("{id:int}")]
        public async Task<IActionResult> UdateLead([FromRoute] int id, [FromBody] Lead lead){
            var updateDomian = await leadRepository.UpdateLeadAsync(id , lead);
            if (updateDomian == null)
            {
                return NotFound();
            }

            return Ok(updateDomian);
        }

        [HttpDelete]
        [Route ("{id:int}")]
        public async Task<IActionResult> DeleteLeads([FromRoute] int id)
        {
            var deletLeading = await leadRepository.DeleteLeadAsync(id);
            if (deletLeading == null)
            {
                return NotFound();
            }

            return Ok(deletLeading);
        }
    }

}