using Business.Commands;
using Core;
using Core.Interfaces;
using Data;
using Data.Entity;
using Microsoft.Extensions.Logging;

namespace Business.Handlers
{
    /// <summary>
    /// Handles commands to purge tasks
    /// </summary>
    public class PurgeCompledTasksCommandHandler(ILogger<PurgeCompledTasksCommandHandler> logger, ICrud<TTask> taskCrud, ITaskQuery taskQuery)
        : ICommandHandler<PurgeTasksCommand, Result<bool>>, ISaveChanges
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns>A result indicating success or failure of operation and the list of tasks.</returns>
        public async Task<Result<bool>> Execute(PurgeTasksCommand command)
        {
            try
            {
                var completedTasks = await taskQuery.GetClientCompletedTasks(command.ClientId);

                foreach (var task in completedTasks)
                {
                    taskCrud.Remove(task);
                }

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError("Error purging completed tasks: {ErrorMessage}", ex.Message);
                return new Error("Something went wrong purging comleted tasks");
            }
        }
    }
}
