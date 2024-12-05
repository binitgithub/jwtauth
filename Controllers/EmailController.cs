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
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepository emailRepository;

        public EmailController(IEmailRepository emailRepository)
        {
            this.emailRepository = emailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmail()
        {
            var GetEmailModelAll = await emailRepository.GetAllEmailAsync();
            return Ok(GetEmailModelAll);
        }

        [HttpGet ("{id:int}")]
        public async Task<IActionResult> GetEmailById([FromRoute] int id)
        {
            var GetEmailModel = await emailRepository.GetEmailByIdAsync(id);
            if (GetEmailModel == null)
            {
                return NotFound();
            }

            return Ok(GetEmailModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmailAll([FromBody] Email email)
        {
            var CreateEmailModel = await emailRepository.CreateEmailAsync(email);
            return CreatedAtAction(nameof(GetEmailById), new {CreateEmailModel.EmailId}, CreateEmailModel);
        }

        [HttpPut]
        [Route ("{id:int}")]
        public async Task<IActionResult> UpdateEmail([FromRoute] int id, [FromBody] Email email)
        {
            var UpdateEmailModels = await emailRepository.UpdateEmailAsync(id, email);
            if (UpdateEmailModels == null)
            {
                return NotFound();
            }

            return Ok(UpdateEmailModels);
        }

        [HttpDelete]
        [Route ("{id:int}")]
        public async Task<IActionResult> DeleteEmail([FromRoute] int id)
        {
            var delteEmailModel = await emailRepository.DeleteEmailAsync(id);
            if (delteEmailModel == null)
            {
                return NotFound();
            }

            return Ok(delteEmailModel);
        }
    }
}