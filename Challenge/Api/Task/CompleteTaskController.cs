using Business.Commands;
using Core;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Api.Task
{
    /// <summary>
    /// Controller to complete a task. 
    /// </summary>
    [Route("api/task/complete")]
    [ApiController]
    public class CompleteTaskController(ICommandHandler<CompleteTaskCommand, Result<bool>> commandHandler) : ControllerBase
    {
        /// <summary>
        /// Executes the complete task command, forwarding the data to the associated command.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<Result<bool>>> Execute([FromBody] CompleteTaskCommand command)
        {
            var result = await commandHandler.Execute(command);
            if (result)
            {
                return Ok(result);
            }
            return UnprocessableEntity(result);
        }
    }
}
