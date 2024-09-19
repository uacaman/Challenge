using Business.Commands;
using Core;
using Core.Interfaces;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Api.Task
{
    /// <summary>
    /// Controller for purging tasks. 
    /// </summary>
    [Route("api/task/purge")]
    [ApiController]
    public class PurgeTasksController(ICommandHandler<PurgeTasksCommand, Result<bool>> purgeTasksCommandHandler) : ControllerBase
    {
        /// <summary>
        /// Executes the command to purge completed tasks
        /// </summary>
        [HttpDelete]
        public async Task<ActionResult<Result<bool>>> Execute([FromBody] PurgeTasksCommand command)
        {
            var result = await purgeTasksCommandHandler.Execute(command);
            if (result)
            {
                return Ok(result);
            }
            return UnprocessableEntity(result);
        }
    }
}
