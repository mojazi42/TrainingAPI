using TrainingAPI.DTOs;
using TrainingAPI.Models;

namespace TrainingAPI.Services
{
    public interface IWorkoutService
    {
        List<Workout> GetAll();

        Workout? GetById(int id);

        Workout? CreateWorkout(CreateWorkoutDto workout);

        Workout? UpdateWorkout(int id, Workout workout);

        Workout? DeleteWorkout(int id);

    }
}
