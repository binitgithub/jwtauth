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
    public class AppTasksController : ControllerBase
    {
        private readonly IAppTaskRepository appTaskRepository;

        public AppTasksController(IAppTaskRepository appTaskRepository)
        {
            this.appTaskRepository = appTaskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppTask()
        {
            var appTaskModel = await appTaskRepository.GetAppTaskAsync();
            return Ok(appTaskModel);
        }
       [HttpGet("{id:int}")]
        public async Task<IActionResult> AppTaskGeById([FromRoute] int id)
        {
            var AppTaskid = await appTaskRepository.GetAppTaskByIdAsync(id);
            if (AppTaskid == null)
            {
                return NotFound();
            }
            return Ok(AppTaskid);
        }
        [HttpPost]
        public async Task<IActionResult> CreatAppTask([FromBody] AppTask appTask)
        {
            var AppTaskModelcreate = await appTaskRepository.CreateTaskAppAsync(appTask);
            return CreatedAtAction(nameof(AppTaskGeById), new {id = AppTaskModelcreate.AppTaskId},AppTaskModelcreate );
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAppTask([FromRoute] int id, [FromBody] AppTask appTask)
        {
            var ModelAppTask = await appTaskRepository.UpdateTaskAppAsync(id, appTask);
            if (ModelAppTask == null)
            {
                return NotFound();
            }

            return Ok(ModelAppTask);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAppTask([FromRoute] int id)
        {
            var deleteModel = await appTaskRepository.DeleteTaskAppAsync(id);
            if (deleteModel == null)
            {
                return NotFound();
            }
            return Ok(deleteModel);
        }
    }
}