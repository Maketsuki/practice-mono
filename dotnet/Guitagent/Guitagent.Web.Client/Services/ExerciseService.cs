using System.Net.Http.Json;
using Guitagent.Shared.DTOs;

namespace Guitagent.Web.Client.Services;

public class ExerciseService(HttpClient httpClient) : IExerciseService
{
    public async Task<List<ExerciseDto>> GetExercisesAsync()
    {
        return await httpClient.GetFromJsonAsync<List<ExerciseDto>>("api/exercises") ?? [];
    }

    public async Task CreateExerciseAsync(CreateExerciseDto exercise)
    {
        await httpClient.PostAsJsonAsync("api/exercises", exercise);
    }
}
