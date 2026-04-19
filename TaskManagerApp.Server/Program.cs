using FluentValidation;
using TaskManagerApp.Server.TaskManager.Application.DTOs;
using TaskManagerApp.Server.TaskManager.Application.Interfaces;
using TaskManagerApp.Server.TaskManager.Application.Services;
using TaskManagerApp.Server.TaskManager.Application.Validators;
using TaskManagerApp.Server.TaskManager.Domain.Interfaces;
using TaskManagerApp.Server.TaskManager.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();

//Validator for CreateTaskRequest
builder.Services.AddScoped<IValidator<CreateTaskRequest>, CreateTaskValidator>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Swagger (enable always for now)
app.UseSwagger();
app.UseSwaggerUI();

// Static files (optional)
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();



app.UseCors("AllowAll");


app.MapControllers();

// Optional SPA fallback
app.MapFallbackToFile("/index.html");

app.Run();