using Microsoft.AspNetCore.Http.HttpResults;
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

        public List<ExerciseDetailDto> GetAll(){
            return _context.Exercises
                .Select(e => new ExerciseDetailDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    MetricType = e.MetricType,
                    RepsCount = e.RepsCount,
                    DurationSeconds = e.DurationSeconds,
                }
                ).ToList();

        }


        public ExerciseDetailDto? GetById(int Id)
        {

            var exercise = _context.Exercises.FirstOrDefault(e => e.Id == Id);
            if (exercise is null)
                return null;

            return new ExerciseDetailDto
            {
                Id = exercise.Id,
                Name = exercise.Name,
                DurationSeconds = exercise.DurationSeconds,
                MetricType = exercise.MetricType,
                RepsCount = exercise.RepsCount,
            };
        }


        

        public ExerciseDetailDto? CreateExercise(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            _context.SaveChanges();
            return  new ExerciseDetailDto
            {
                Id = exercise.Id,
                Name = exercise.Name,
                DurationSeconds = exercise.DurationSeconds,
                MetricType = exercise.MetricType,
                RepsCount = exercise.RepsCount,
            };
        }

        public Exercise? UpdateExercise(int Id, Exercise exercise)
        {

            var exerciseOld = _context.Exercises.FirstOrDefault(e => e.Id == Id);

            if (exerciseOld is null)
            {
                return null;
            }

            exerciseOld.Name = exercise.Name;
            exerciseOld.MetricType = exercise.MetricType;
            exerciseOld.RepsCount = exercise.RepsCount;
            exerciseOld.DurationSeconds = exercise.DurationSeconds;

            _context.SaveChanges();

            return exerciseOld;
        }

        public Exercise? DeleteExercise(int Id)
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