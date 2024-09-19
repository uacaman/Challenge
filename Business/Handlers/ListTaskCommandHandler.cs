using Business.Commands;
using Core;
using Core.Interfaces;
using Data;
using Data.Entity;
using Microsoft.Extensions.Logging;

namespace Business.Handlers
{
    /// <summary>
    /// Handles commands for listing tasks.
    /// </summary>
    public class ListTaskCommandHandler(ILogger<ListTaskCommandHandler> logger, ITaskQuery taskQuery)
        : ICommandHandler<ListTaskCommand, Result<List<TTask>>>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns>A result indicating success or failure of operation and the list of tasks.</returns>
        public async Task<Result<List<TTask>>> Execute(ListTaskCommand command)
        {
            try
            {
                var records = await taskQuery.GetClientTaskNoTracking(command.ClientId);
                return records.OrderByDescending(q => q.Id).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError("Error listing tasks: {ErrorMessage}", ex.Message);
                return new Error("Something went wrong listing tasks");
            }
        }
    }
}
