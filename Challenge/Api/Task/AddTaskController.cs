using Business.Commands;
using Core;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Api.Task
{
    /// <summary>
    /// Controller to add a task
    /// </summary>
    [Route("api/task/add")]
    [ApiController]
    public class AddTaskController(ICommandHandler<AddTaskCommand, Result<bool>> addTaskCommandHandler) : ControllerBase
    {
        /// <summary>
        /// Executes the command to add a task item, forwarding the data to the associated command handler 
        /// to handle the bussines logic
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Result<bool>>> Execute([FromBody] AddTaskCommand command)
        {
            var result = await addTaskCommandHandler.Execute(command);
            if (result)
            {
                return Ok(result);
            }
            return UnprocessableEntity(result);
        }
    }
}
