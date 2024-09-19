using Business.Commands;
using Core;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Api.Task
{
    /// <summary>
    /// Controller to delete a task item
    /// </summary>
    [Route("api/task/del")]
    [ApiController]
    public class DelTaskController(ICommandHandler<DelTaskCommand, Result<bool>> delTaskCommandHandler) : ControllerBase
    {
        /// <summary>
        /// Executes the command to delete a task item, forwarding the data to the associated command handler 
        /// to handle the bussines logic
        /// </summary>
        [HttpDelete]
        public async Task<ActionResult<Result<bool>>> Execute([FromBody] DelTaskCommand command)
        {
            var result = await delTaskCommandHandler.Execute(command);
            if (result)
            {
                return Ok(result);
            }
            return UnprocessableEntity(result);
        }
    }
}
