using Business.Commands;
using Core;
using Core.Interfaces;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Api.Task
{
    /// <summary>
    /// Controller for listing all tasks
    /// </summary>
    [Route("api/task/list")]
    [ApiController]
    public class ListTaskController(ICommandHandler<ListTaskCommand, Result<List<TTask>>> listTaskCommandHandler) : ControllerBase
    {
        /// <summary>
        /// Executes the command to list all task items, forwarding the data to the associated command handler 
        /// to handle the bussines logic
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<Result<bool>>> Execute([FromQuery] string clientId)
        {
            var listTaskCommand = new ListTaskCommand()
            {
                ClientId = clientId
            };

            var result = await listTaskCommandHandler.Execute(listTaskCommand);
            if (result)
            {
                return Ok(result);
            }
            return UnprocessableEntity(result);
        }
    }
}
