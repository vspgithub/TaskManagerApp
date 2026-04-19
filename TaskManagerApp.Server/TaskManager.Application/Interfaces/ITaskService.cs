using TaskManagerApp.Server.TaskManager.Application.DTOs;


namespace TaskManagerApp.Server.TaskManager.Application.Interfaces
{
    // This interface defines the contract for task-related operations in the application layer.
    // It abstracts the business logic for managing tasks, allowing for separation of concerns and easier testing.
    // The ITaskService interface includes methods for retrieving all tasks and creating a new task asynchronously.
    public interface ITaskService
    {
        Task<IEnumerable<TaskResponse>> GetTasksAsync();
        Task<TaskResponse> CreateTaskAsync(CreateTaskRequest request);
    }
}
