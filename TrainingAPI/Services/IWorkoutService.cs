using TrainingAPI.DTOs;
using TrainingAPI.Models;

namespace TrainingAPI.Services
{
    public interface IWorkoutService
    {
        List<Workout> GetAll();

        WorkoutResponseDto? GetById(int id);

        Workout? CreateWorkout(CreateWorkoutDto dto);

        Workout? UpdateWorkout(int id, CreateWorkoutDto dto);

        Workout? DeleteWorkout(int id);

        WorkoutExercise? AddExerciseToWorkout(int workoutId, AddExerciseToWorkoutDto dto);

        Set? LogSet(int workoutId, int exerciseId, LogSetDto dto);

    }
}
