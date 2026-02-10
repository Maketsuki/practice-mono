namespace Guitagent.Domain.Entities;

public class Routine
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = default!;
    public DateOnly Date { get; set; }
    public ICollection<RoutineExercise> Exercises { get; set; } = new List<RoutineExercise>();
}

public class RoutineExercise
{
    public Guid Id { get; set; }
    public Guid RoutineId { get; set; }
    public Routine Routine { get; set; } = default!;
    public Guid ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = default!;
    public int DurationMinutes { get; set; }
    public int Order { get; set; }
    public bool IsCompleted { get; set; }
}
