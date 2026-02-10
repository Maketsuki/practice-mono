using Guitagent.Domain.Entities;
using Guitagent.Infrastructure.Data;
using Guitagent.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Guitagent.API.Features.Exercises;

public static class ExerciseEndpoints
{
    public static void MapExerciseEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/exercises");

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Exercises
                .Select(e => new ExerciseDto(e.Id, e.Name, e.Description, e.Type, e.SkillLevel, e.DefaultDurationMinutes))
                .ToListAsync();
        });

        group.MapPost("/", async (CreateExerciseDto dto, ApplicationDbContext db) =>
        {
            var exercise = new Exercise
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Type = dto.Type,
                SkillLevel = dto.SkillLevel,
                DefaultDurationMinutes = dto.DefaultDurationMinutes
            };

            db.Exercises.Add(exercise);
            await db.SaveChangesAsync();

            return Results.Created($"/api/exercises/{exercise.Id}", 
                new ExerciseDto(exercise.Id, exercise.Name, exercise.Description, exercise.Type, exercise.SkillLevel, exercise.DefaultDurationMinutes));
        });
    }
}
