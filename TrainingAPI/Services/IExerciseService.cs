using TrainingAPI.DTOs;
using TrainingAPI.Models;

namespace TrainingAPI.Services
{
    public interface IExerciseService
    {
        List<ExerciseDetailDto> GetAll();

        ExerciseDetailDto? GetById(int id);

        ExerciseDetailDto? CreateExercise(Exercise exercise);

        Exercise? UpdateExercise(int id, Exercise updateExercises);

        Exercise? DeleteExercise(int id);
    }
}
