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
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllContact()
        {
            var ContactGetModel =  await contactRepository.GetContactAsync();
            return Ok(ContactGetModel);
        }

        [HttpGet ("{id:int}")]
        public async Task<IActionResult> GetByIdContact([FromRoute] int id)
        {
            var GetByIdContactModel = await contactRepository.GetContactByIdAsync(id);
            if (GetByIdContactModel == null)
            {
                return NotFound();
            }
            return Ok(GetByIdContactModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] Contact contact)
        {
            var CreateModels = await contactRepository.CreateContactAsync(contact);
            return CreatedAtAction(nameof(GetByIdContact), new {CreateModels.ContactId}, CreateModels);
        }

        [HttpPut]
        [Route ("{id:int}")]
        public async Task<IActionResult> UpdateContact([FromRoute]int id, [FromBody] Contact contact)
        {
            var updateContactModel = await contactRepository.UpdateContactAsync(id , contact);
            if (updateContactModel == null)
            {
                return NotFound();
            }

            return Ok(updateContactModel);
        }

        [HttpDelete]
        [Route ("{id:int}")]
        public async Task<IActionResult> DeleteContact([FromRoute]int id)
        {
            var deleteContactModel = await contactRepository.DeleteContactAsync(id);
            if (deleteContactModel == null)
            {
                return NotFound();
            }
            return Ok(deleteContactModel);
        }
    }
}