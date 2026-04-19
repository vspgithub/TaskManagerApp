using FluentValidation.TestHelper;
using TaskManagerApp.Server.TaskManager.Application.DTOs;
using TaskManagerApp.Server.TaskManager.Application.Validators;
using Xunit;

public class CreateTaskValidatorTests
{
    private readonly CreateTaskValidator _validator = new();

    [Fact]
    public void Should_Have_Error_When_Title_Is_Empty()
    {
        var model = new CreateTaskRequest
        {
            Title = ""
        };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    [Fact]
    public void Should_Have_Error_When_DueDate_Is_In_Past()
    {
        var model = new CreateTaskRequest
        {
            Title = "Valid Title",
            DueDate = DateTime.UtcNow.AddDays(-1)
        };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.DueDate);
    }

    [Fact]
    public void Should_Pass_When_Model_Is_Valid()
    {
        var model = new CreateTaskRequest
        {
            Title = "Valid",
            Priority = "Low",
            DueDate = DateTime.UtcNow.AddDays(1)
        };

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveAnyValidationErrors();
    }
}