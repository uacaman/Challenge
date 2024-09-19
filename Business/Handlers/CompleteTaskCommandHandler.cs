using Business.Commands;
using Core;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Business.Handlers
{
    /// <summary>
    /// Handles commands for completing tasks.
    /// </summary>
    public class CompleteTaskCommandHandler(ILogger<CompleteTaskCommandHandler> logger, 
        ICommandHandler<UpdateTaskCommand, Result<bool>> updateTaskCommandHandler) 
        : ICommandHandler<CompleteTaskCommand, Result<bool>>
    {

        /// <summary>
        /// Executes the complete task command
        /// </summary>
        /// <param name="command">The command containing the task details.</param>
        /// <returns>A result indicating success or failure of the update operation.</returns>
        public async Task<Result<bool>> Execute(CompleteTaskCommand command)
        {
            try
            {
                var updateCommand = new UpdateTaskCommand()
                {
                    ClientId = command.ClientId,
                    Id = command.Id,
                    Completed = true
                };

                var result = await updateTaskCommandHandler.Execute(updateCommand);

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError("Error completing task: {ErrorMessage}", ex.Message);
                return new Error("Something went wrong completing task");
            }
        }
    }
}
