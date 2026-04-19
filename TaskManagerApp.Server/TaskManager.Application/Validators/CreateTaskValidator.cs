using FluentValidation;
using TaskManagerApp.Server.TaskManager.Application.DTOs;

namespace TaskManagerApp.Server.TaskManager.Application.Validators
{
    public class CreateTaskValidator : AbstractValidator<CreateTaskRequest>
    {
        // The CreateTaskValidator class defines validation rules for the CreateTaskRequest DTO using FluentValidation.
        public CreateTaskValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .MaximumLength(500);

            RuleFor(x => x.Priority)
                .Must(p => new[] { "Low", "Medium", "High" }.Contains(p))
                .WithMessage("Invalid priority");

            RuleFor(x => x.DueDate)
                .Must(d => !d.HasValue || d.Value.Date >= DateTime.UtcNow.Date)
                .WithMessage("Due date cannot be in the past");
        }
    }
}
