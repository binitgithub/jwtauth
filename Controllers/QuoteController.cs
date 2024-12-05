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
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteRepository quoteRepository;

        public QuoteController(IQuoteRepository quoteRepository)
        {
            this.quoteRepository = quoteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuote()
        {
            var GetQuoteModel = await quoteRepository.GetQuoteAsync();
            return Ok(GetQuoteModel);
        }

        [HttpGet ("{id:int}")]
        public async Task<IActionResult> GetQuoteById([FromRoute] int id)
        {
            var GetByIdModel = await quoteRepository.GetQuoteByIdAsync(id);
            if (GetByIdModel == null)
            {
                return NotFound();
            }
            return Ok(GetByIdModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuote([FromBody] Quote quote)
        {
            var CreateQuoteModel = await quoteRepository.CreateQuoteAsync(quote);
            return CreatedAtAction(nameof(GetQuoteById), new {CreateQuoteModel.QuoteId}, CreateQuoteModel);
        }

        [HttpPut]
        [Route ("{id:int}")]
        public async Task<IActionResult> UpdateQuote([FromRoute]int id, [FromBody] Quote quote)
        {
            var updateQuoteModel = await quoteRepository.UpdateQuoteAsync(id, quote);
            if (updateQuoteModel == null)
            {
                return NotFound();
            }
            return Ok(updateQuoteModel);
        }

        [HttpDelete]
        [Route ("{id:int}")]
        public async Task<IActionResult> DeleteQuote([FromRoute]int id)
        {
            var DeleteQuoteModel = await quoteRepository.DeleteQuoteAsync(id);
            if (DeleteQuoteModel == null)
            {
                return NotFound();
            }
            return Ok(DeleteQuoteModel);
        }
    }
}