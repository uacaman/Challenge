using Data.Entity;

namespace Data
{
    public interface ITaskQuery
    {
        Task<List<TTask>> GetClientCompletedTasks(string clientId);
        Task<List<TTask>> GetClientTaskNoTracking(string clientId);
    }
}