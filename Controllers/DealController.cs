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
    public class DealController : ControllerBase
    {
        private readonly IDealRepository dealRepository;

        public DealController(IDealRepository dealRepository)
        {
            this.dealRepository = dealRepository;
        }
    
    [HttpGet]
    public async Task<IActionResult> GetDeal()
    {
        var DealModels = await dealRepository.GetDealAsync();
        return Ok(DealModels);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDelById([FromRoute] int id)
    {
        var ceateModel = await dealRepository.GetDealByIdAsync(id);
        if (ceateModel == null)
        {
            return NotFound();
        }
        return Ok(ceateModel);
    }
    [HttpPost]
    public async Task<IActionResult> CreteDeal(Deal deal)
    {
        var PostModel = await dealRepository.CreateDealAsync(deal);
        return CreatedAtAction(nameof(GetDelById), new {id = PostModel.DealId}, PostModel);
    }

    [HttpPut]
    [Route ("{id:int}")]
    public async Task<IActionResult> UpdateDeal([FromRoute] int id, [FromBody] Deal deal )
    {
        var updateModels = await dealRepository.UpdateDealAsync(id, deal);
        if (updateModels == null)
        {
            return NotFound();
        } 

        return Ok(updateModels);
    }

    [HttpDelete]
    [Route ("{id:int}")]
    public async Task<IActionResult> DeleteDeal([FromRoute] int id)
    {
        var deleteModel = await dealRepository.DeleteAsync(id);
        if (deleteModel == null)
        {
            return NotFound();
        }

        return Ok(deleteModel);
    }
    }
}