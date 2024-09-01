using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services;
using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.WebApi.Models;
using UKParliament.CodeTest.WebApi.Middleware;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoListContext>(op => op.UseInMemoryDatabase("TodoListManager"));
// adding AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// exception handling
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddLogging();

builder.Services.AddScoped<ITodoListService, TodoListService>();
builder.Services.AddScoped<ITodoListRepository, TodoListRepository>();
builder.Services.AddScoped<IToDoItemValidator, ToDoItemValidator>();

var app = builder.Build();

// Create database so the data seeds
using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    using var context = serviceScope.ServiceProvider.GetRequiredService<TodoListContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
