using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TrainingAPI.Data;
using TrainingAPI.DTOs;
using TrainingAPI.Models;
using TrainingAPI.Services;

namespace TrainingAPI.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly TrainingDbContext _context;

        public ExerciseService(TrainingDbContext context)
        {

            _context = context;

        }

    
        public async Task<List<ExerciseDetailDto>> GetAll(){

            return await _context.Exercises
                .Select(e => new ExerciseDetailDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    MetricType = e.MetricType,
                    RepsCount = e.RepsCount,
                    DurationSeconds = e.DurationSeconds,
                }
                ).ToListAsync();

        }


        public async Task<ExerciseDetailDto?> GetById(int Id)
        {

            var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == Id);
            if (exercise is null)
                return null;

            return new  ExerciseDetailDto
            {
                Id = exercise.Id,
                Name = exercise.Name,
                DurationSeconds = exercise.DurationSeconds,
                MetricType = exercise.MetricType,
                RepsCount = exercise.RepsCount,
            };
        }


        

        public async Task<ExerciseDetailDto?> CreateExercise(CreateExerciseDto dto)
        {
            var exercise = new Exercise
            {
                Name = dto.Name,
                MetricType = dto.MetricType,
                RepsCount = dto.RepsCount,
                DurationSeconds = dto.DurationSeconds
            };
            _context.Exercises.Add(exercise);
            _context.SaveChanges();
            return  new ExerciseDetailDto
            {
                Id = exercise.Id,
                Name = exercise.Name,
                MetricType = exercise.MetricType,
                RepsCount = exercise.RepsCount,
                DurationSeconds = exercise.DurationSeconds,
            };
        }

        public async Task <ExerciseDetailDto?> UpdateExercise(int Id, CreateExerciseDto dto)
        {

            var exerciseOld = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == Id);

            if (exerciseOld is null)
            {
                return null;
            }
            

            exerciseOld.Name = dto.Name;
            exerciseOld.MetricType = dto.MetricType;
            exerciseOld.RepsCount = dto.RepsCount;
            exerciseOld.DurationSeconds = dto.DurationSeconds;

            await _context.SaveChangesAsync();



            return new ExerciseDetailDto
            {
                Id = exerciseOld.Id,
                Name = exerciseOld.Name,
                MetricType = exerciseOld.MetricType,
                RepsCount = exerciseOld.RepsCount,
                DurationSeconds = exerciseOld.DurationSeconds

            };


        }

        public async Task <Exercise?> DeleteExercise(int Id)
        {

            var exercise = _context.Exercises.FirstOrDefault(e => e.Id == Id);

            if (exercise is null)
            {
                return null;
            }

            _context.Exercises.Remove(exercise);

            _context.SaveChanges();

            return exercise;


        }
    }
}