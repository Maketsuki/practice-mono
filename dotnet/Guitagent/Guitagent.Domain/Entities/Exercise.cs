using Guitagent.Shared.Enums;

namespace Guitagent.Domain.Entities;

public class Exercise
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ExerciseType Type { get; set; }
    public SkillLevel SkillLevel { get; set; }
    public int DefaultDurationMinutes { get; set; }
}
