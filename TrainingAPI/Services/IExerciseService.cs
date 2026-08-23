using TrainingAPI.DTOs;
using TrainingAPI.Models;

namespace TrainingAPI.Services
{
    public interface IExerciseService
    {
        Task<List<ExerciseDetailDto>> GetAll();

        Task<ExerciseDetailDto?> GetById(int id);

        Task <ExerciseDetailDto?> CreateExercise(CreateExerciseDto dto);

        Task <ExerciseDetailDto?> UpdateExercise(int id, CreateExerciseDto updateExercises);

        Task <Exercise?> DeleteExercise(int id);
    }
}
