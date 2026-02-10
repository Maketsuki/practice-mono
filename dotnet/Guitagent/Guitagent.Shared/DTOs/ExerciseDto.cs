using Guitagent.Shared.Enums;

namespace Guitagent.Shared.DTOs;

public record ExerciseDto(Guid Id, string Name, string Description, ExerciseType Type, SkillLevel SkillLevel, int DefaultDurationMinutes);
public record CreateExerciseDto(string Name, string Description, ExerciseType Type, SkillLevel SkillLevel, int DefaultDurationMinutes);
