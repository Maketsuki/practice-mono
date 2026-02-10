using Guitagent.Infrastructure.Data;
using Guitagent.API.Features.Exercises;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceDefaults();
builder.AddNpgsqlDbContext<ApplicationDbContext>("guitagent-db");

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapDefaultEndpoints();
app.MapExerciseEndpoints();

app.UseHttpsRedirection();

app.Run();
