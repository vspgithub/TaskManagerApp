using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.Server.TaskManager.Application.DTOs;
using TaskManagerApp.Server.TaskManager.Application.Interfaces;

namespace TaskManagerApp.Server.TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            //Dependency Injection of the service.
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await _service.GetTasksAsync();
            return Ok(tasks);
        } 


        [HttpPost]
        public async Task<IActionResult> Create(
        [FromBody] CreateTaskRequest request,
        [FromServices] IValidator<CreateTaskRequest> validator)
        {
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    errors = validationResult.Errors.Select(e => e.ErrorMessage)
                });
            }

            var createdTask = await _service.CreateTaskAsync(request);

            return Created($"api/tasks/{createdTask.Id}", createdTask);
        }

    }
}
