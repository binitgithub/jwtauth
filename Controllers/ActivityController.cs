using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Models;
using jwtauth.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;

namespace jwtauth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityRepository activityRepository;

        public ActivityController(IActivityRepository activityRepository)
        {
            this.activityRepository = activityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivity()
        {
            var GetActivityModel = await activityRepository.GetActivityAsync();
            return Ok(GetActivityModel);
        }
        [HttpGet ("{id:int}")]
        public async Task<IActionResult> GetActivityById([FromRoute] int id)
        {
            var GetIdModel = await activityRepository.GetActivityByIdAsync(id);
            if (GetIdModel == null)
            {
                return NotFound();
            }
            return Ok(GetIdModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
        {
            var CreateActivityModel = await activityRepository.CreateActivityAsync(activity);
            return CreatedAtAction(nameof(GetActivityById), new {id = CreateActivityModel.ActivityId }, CreateActivityModel);
        }

        [HttpPut]
        [Route ("{id:int}")]
        public async Task<IActionResult> UpdateActivity([FromRoute] int id, [FromBody] Activity activity)
        {
            var UpdateActivityModel = await activityRepository.UpdateActivityAsync(id , activity);
            if (UpdateActivityModel == null)
            {
                return NotFound();
            }

            return Ok(UpdateActivityModel);
        }

        [HttpDelete]
        [Route ("{id:int}")]
        public async Task<IActionResult> DeleteActivity([FromRoute] int id)
        {
            var DeleteActiveModel = await activityRepository.DeleteActivityByIdAsync(id);
            if (DeleteActiveModel == null)
            {
                return NotFound();
            } 

            return Ok(DeleteActiveModel);
        }
    }
}