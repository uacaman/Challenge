using Business.Commands;
using Core;
using Core.Interfaces;
using Data.Entity;
using Microsoft.Extensions.Logging;

namespace Business.Handlers
{
    /// <summary>
    /// Handles commands for deleting tasks.
    /// </summary>
    /// 
    public class DelTaskCommandHandler(ILogger<DelTaskCommandHandler> logger, ICrud<TTask> taskCrud)
        : ICommandHandler<DelTaskCommand, Result<bool>>, ISaveChanges
    {
        /// <summary>
        /// Executes the delete task command
        /// </summary>
        /// <param name="command">The command containing the task details.</param>
        /// <returns>A result indicating success or failure of the update operation.</returns>
        public async Task<Result<bool>> Execute(DelTaskCommand command)
        {
            try
            {
                var task = await taskCrud.ByIdAsync(command.Id);
                if (task == null || task.ClientId != command.ClientId)
                {
                    return new Error("Opps, looks like this task was already deleted");
                }

                taskCrud.Remove(task);

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError("Error deleting task:{ErrorMessage}", ex.Message);
                return new Error("Something went wrong deleting task");
            }
        }
    }
}
