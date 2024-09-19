using Business.Commands;
using Core;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Api.Task
{
    /// <summary>
    /// Controller to update a task name
    /// </summary>
    [Route("api/task/update")]
    [ApiController]
    public class UpdateTaskNameController(ICommandHandler<UpdateTaskCommand, Result<bool>> commandHandler) : ControllerBase
    {
        /// <summary>
        /// Executes the update task command, forwarding the data to the associated command.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<Result<bool>>> Execute([FromBody] UpdateTaskNameCommand command)
        {
            var updateTaskCommand = new UpdateTaskCommand()
            {
                ClientId = command.ClientId,
                Id = command.Id,
                Name = command.Name
            };

            var result = await commandHandler.Execute(updateTaskCommand);
            if (result)
            {
                return Ok(result);
            }

            return UnprocessableEntity(result);
        }
    }
}
