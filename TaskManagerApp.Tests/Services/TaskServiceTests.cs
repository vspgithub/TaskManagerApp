using Moq;
using Xunit;
using TaskManagerApp.Server.TaskManager.Application.DTOs;
using TaskManagerApp.Server.TaskManager.Application.Services;
using TaskManagerApp.Server.TaskManager.Domain.Entities;
using TaskManagerApp.Server.TaskManager.Domain.Interfaces;


public class TaskServiceTests
{
    [Fact]
    public async Task CreateTask_Should_Save_Task_When_Valid()
    {
        // Arrange
        var repoMock = new Mock<ITaskRepository>();

        repoMock
            .Setup(r => r.AddAsync(It.IsAny<TaskItem>()))
            .Returns(Task.CompletedTask);

        var service = new TaskService(repoMock.Object);

        var request = new CreateTaskRequest
        {
            Title = "TestTask",
            Description = "Test Task Desc",
            Priority = "Low",
            DueDate = DateTime.UtcNow.AddDays(1)
        };

        // Act
        var result = await service.CreateTaskAsync(request);

        // Assert
        Assert.Equal("TestTask", result.Title);

        repoMock.Verify(r => r.AddAsync(It.IsAny<TaskItem>()), Times.Once);
    }
}