using TrainingAPI.Models;

namespace TrainingAPI.Services
{
    public interface IWorkoutService
    {
        List<Workout> GetAll();

        Workout? GetById(int id);

        Workout? CreateWorkout(Workout workout);
        
    }
}
