using TrainingAPI.DTOs;
using TrainingAPI.Models;

namespace TrainingAPI.Services
{
    public interface IWorkoutService
    {
        Task<List<Workout>> GetAll();

        Task<WorkoutResponseDto?> GetById(int id);

        Task<Workout?> CreateWorkout(CreateWorkoutDto dto);

        Task<Workout?> UpdateWorkout(int id, CreateWorkoutDto dto);

        Task<Workout?> DeleteWorkout(int id);

        Task<WorkoutExercise?> AddExerciseToWorkout(int workoutId, AddExerciseToWorkoutDto dto);

        Task<Set?> LogSet(int workoutId, int exerciseId, LogSetDto dto);

    }
}
