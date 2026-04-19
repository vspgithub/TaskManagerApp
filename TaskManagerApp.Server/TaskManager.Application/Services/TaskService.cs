using TaskManagerApp.Server.TaskManager.Application.DTOs;
using TaskManagerApp.Server.TaskManager.Application.Interfaces;
using TaskManagerApp.Server.TaskManager.Domain.Entities;
using TaskManagerApp.Server.TaskManager.Domain.Interfaces;


namespace TaskManagerApp.Server.TaskManager.Application.Services
{
    //TaskService implements the ITaskService interface and provides the business logic for managing tasks.
    // It interacts with the ITaskRepository to perform data access operations, such as retrieving all tasks and adding a new task.
    // The service methods are asynchronous, allowing for non-blocking operations and better performance when dealing with I/O-bound tasks.
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repo;

        public TaskService(ITaskRepository repo)
        {
            //Dependency Injection of the repository.
            _repo = repo;
        }

        // The GetTasksAsync method retrieves all tasks from the repository, maps them to TaskResponse DTOs, and returns the list of tasks.
        public async Task<IEnumerable<TaskResponse>> GetTasksAsync()
        {
            var tasks = await _repo.GetAllAsync();

            return tasks.Select(t => new TaskResponse
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                Priority = t.Priority
            });
        }

        // The CreateTaskAsync method creates a new task based on the provided CreateTaskRequest,
        // adds it to the repository, and returns a TaskResponse with the details of the created task.
        public async Task<TaskResponse> CreateTaskAsync(CreateTaskRequest request)
        {
            var entity = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                Priority = request.Priority
            };

            await _repo.AddAsync(entity);

            return new TaskResponse
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                DueDate = entity.DueDate,
                Priority = entity.Priority
            };
        }
    }
}
