using Guitagent.Shared.DTOs;

namespace Guitagent.Web.Client.Services;

public interface IExerciseService
{
    Task<List<ExerciseDto>> GetExercisesAsync();
    Task CreateExerciseAsync(CreateExerciseDto exercise);
}
