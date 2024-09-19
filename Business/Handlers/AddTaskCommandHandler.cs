using Business.Commands;
using Core;
using Core.Interfaces;
using Data.Entity;
using Microsoft.Extensions.Logging;

namespace Business.Handlers
{
    /// <summary>
    /// Handles commands for adding tasks.
    /// </summary>
    public class AddTaskCommandHandler(ILogger<AddTaskCommandHandler> logger, ICrud<TTask> taskCrud) 
        : ICommandHandler<AddTaskCommand, Result<bool>>, ISaveChanges
    {

        /// <summary>
        /// Executes the add task command
        /// </summary>
        /// <param name="command">The command containing the task details.</param>
        /// <returns>A result indicating success or failure of the update operation.</returns>
        public async Task<Result<bool>> Execute(AddTaskCommand command)
        {
            try
            {
                var task = new TTask()
                {
                    ClientId = command.ClientId,
                    Name = command.Name
                };

                await taskCrud.AddAsync(task);

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError("Error adding task: {ErrorMessage}", ex.Message);
                return new Error("Something went wrong adding task");
            }
        }
    }
}
