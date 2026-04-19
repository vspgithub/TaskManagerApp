using TaskManagerApp.Server.TaskManager.Domain.Entities;

namespace TaskManagerApp.Server.TaskManager.Domain.Interfaces
{
    //Task Reposity Interface defines the contract for data access related to TaskItem entities.
    //It abstracts the underlying data storage mechanism, allowing for flexibility in implementation (e.g., in-memory, database, etc.).
    //The interface includes methods for retrieving all tasks and adding a new task asynchronously.
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task AddAsync(TaskItem task);
    }
}
