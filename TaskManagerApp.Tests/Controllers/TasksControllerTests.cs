using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskManagerApp.Server.TaskManager.Api.Controllers;
using TaskManagerApp.Server.TaskManager.Application.DTOs;
using TaskManagerApp.Server.TaskManager.Application.Interfaces;

using Xunit;

public class TasksControllerTests
{
    [Fact]
    public async Task Get_Should_Return_Ok_With_Data()
    {
        // Arrange
        var serviceMock = new Mock<ITaskService>();

        serviceMock
            .Setup(s => s.GetTasksAsync())
            .ReturnsAsync(new List<TaskResponse>
            {
                new TaskResponse { Id = Guid.NewGuid(), Title = "Task 1" }
            });

        var controller = new TasksController(serviceMock.Object);

        // Act
        var result = await controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }
}