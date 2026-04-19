namespace TaskManagerApp.Server.TaskManager.Application.DTOs
{
    // This DTO is used to send task data back to the client. It is a simplified version of the TaskItem entity,
    // containing only the fields that are relevant for the API response.
    public class TaskResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Priority { get; set; } = "Low";
    }
}
