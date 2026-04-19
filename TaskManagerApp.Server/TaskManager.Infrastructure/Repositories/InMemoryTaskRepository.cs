using TaskManagerApp.Server.TaskManager.Domain.Entities;
using TaskManagerApp.Server.TaskManager.Domain.Interfaces;

namespace TaskManagerApp.Server.TaskManager.Infrastructure.Repositories
{
    // InMemoryTaskRepository is a simple implementation of the ITaskRepository interface that uses an in-memory list to store tasks.
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> _tasks = new();

        public Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return Task.FromResult(_tasks.AsEnumerable());
        }

        public Task AddAsync(TaskItem task)
        {
            _tasks.Add(task);
            return Task.CompletedTask;
        }
    }
}
