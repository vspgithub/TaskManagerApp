namespace TaskManagerApp.Server.TaskManager.Application.DTOs
{
    /// This DTO represents the data needed to create a new task.
    // It includes properties for the task's title, description, due date, and priority.
    public class CreateTaskRequest
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Priority { get; set; } = "Low";
    }
}
