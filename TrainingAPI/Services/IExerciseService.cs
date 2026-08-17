using TrainingAPI.DTOs;
using TrainingAPI.Models;

namespace TrainingAPI.Services
{
    public interface IExerciseService
    {
        Task<List<ExerciseDetailDto>> GetAll();

        ExerciseDetailDto? GetById(int id);

        ExerciseDetailDto? CreateExercise(CreateExerciseDto dto);

        Exercise? UpdateExercise(int id, Exercise updateExercises);

        Exercise? DeleteExercise(int id);
    }
}
