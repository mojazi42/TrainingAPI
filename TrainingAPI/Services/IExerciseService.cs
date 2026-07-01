using TrainingAPI.Models;

namespace TrainingAPI.Services
{
    public interface IExerciseService
    {
        List<Exercise> GetAll();
        Exercise? GetById(int id);

        Exercise? CreateExercise(Exercise exercise);

        void UpdateExercise(int id, Exercise updateExercises);

        void DeleteExercise(int id);
    }
}
