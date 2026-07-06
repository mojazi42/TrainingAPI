using TrainingAPI.Models;

namespace TrainingAPI.Services
{
    public interface IExerciseService
    {
        List<Exercise> GetAll();

        Exercise? GetById(int id);

        Exercise? CreateExercise(Exercise exercise);

        Exercise? UpdateExercise(int id, Exercise updateExercises);

        Exercise? DeleteExercise(int id);
    }
}
