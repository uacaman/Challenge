using Business.Commands;
using Core;
using Core.Interfaces;
using Data.Entity;
using Microsoft.Extensions.Logging;

namespace Business.Handlers
{
    /// <summary>
    /// Handles commands for updating tasks.
    /// </summary>
    public class UpdateTaskCommandHandler(ILogger<UpdateTaskCommandHandler> logger, ICrud<TTask> taskCrud) : ICommandHandler<UpdateTaskCommand, Result<bool>>, ISaveChanges
    {
        /// <summary>
        /// Executes the update task command
        /// </summary>
        /// <param name="command">The command containing the task details.</param>
        /// <returns>A result indicating success or failure of the update operation.</returns>
        public async Task<Result<bool>> Execute(UpdateTaskCommand command)
        {
            try
            {
                var task = await taskCrud.ByIdAsync(command.Id);

                if (task == null || task.ClientId != command.ClientId)
                {
                    return new Error("Oops, it looks like this task no longer exists.");
                }

                task.Name = command.Name ?? task.Name!;
                task.Completed = command.Completed ?? task.Completed;

                taskCrud.Update(task);

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError("Error updating task: {Message}", ex.Message);
                return new Error("An error occurred while updating the task.");
            }
        }
    }
}
