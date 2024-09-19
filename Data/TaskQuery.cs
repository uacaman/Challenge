using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class TaskQuery(ChallengeDbContext dbContext) : ITaskQuery
    {
        public async Task<List<TTask>> GetClientTaskNoTracking(string clientId)
        {
            var taskList = dbContext.Set<TTask>()
                .AsNoTracking()
                .Where(q => q.ClientId == clientId)
                .OrderByDescending(q => q.Id).ToListAsync();

            return await taskList;
        }

        public async Task<List<TTask>> GetClientCompletedTasks(string clientId)
        {
            var taskList = dbContext.Set<TTask>()
                .Where(q => q.ClientId == clientId && q.Completed == true)
                .ToListAsync();

            return await taskList;
        }

    }
}
