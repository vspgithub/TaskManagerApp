namespace TaskManagerApp.Server.TaskManager.Domain.Entities
{
    //TaskItem represents a task in the system with properties such as Id, Title, Description, DueDate, and Priority.
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Priority { get; set; } = "Low";
    }
}
