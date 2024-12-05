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
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignRepository campaignRepository;

        public CampaignController(ICampaignRepository campaignRepository)
        {
            this.campaignRepository = campaignRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCampainAll()
        {
            var GetCampainModel = await campaignRepository.GetCampaignAsync();
            return Ok(GetCampainModel);
        }

        [HttpGet ("{id:int}")]
        public async Task<IActionResult> GetByIdCampaign([FromRoute] int id)
        {
            var deleteModelCampain = await campaignRepository.GetCampaignByIdAsync(id);
            if (deleteModelCampain == null)
            {
                return NotFound();
            }

            return Ok(deleteModelCampain);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCampain([FromBody] Campaign campaign)
        {
            var createCampainModel = await campaignRepository.CreateCampaignAsync(campaign);
            return CreatedAtAction(nameof(GetByIdCampaign), new {id = createCampainModel.CampaignId}, createCampainModel);
        }

        [HttpPut]
        [Route ("{id:int}")]
        public async Task<IActionResult> UpdateCampain([FromRoute] int id, [FromBody]Campaign campaign)
        {
            var updateCampModels = await campaignRepository.UpdateCampaignAsync(id , campaign);
            if (updateCampModels == null)
            {
                return NotFound();
            }

            return Ok (updateCampModels);
        }

        [HttpDelete]
        [Route ("{id:int}")]
        public async Task<IActionResult> DeleteCompain([FromRoute] int id)
        {
            var deleteCampainModel = await campaignRepository.DeleteCampaignAsync(id);
            if (deleteCampainModel == null)
            {
                return NotFound();
            }
            return Ok(deleteCampainModel);
        }
    }
}