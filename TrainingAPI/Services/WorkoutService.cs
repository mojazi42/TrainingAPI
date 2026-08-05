using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TrainingAPI.Data;
using TrainingAPI.DTOs;
using TrainingAPI.Models;

namespace TrainingAPI.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly TrainingDbContext _context;

        public WorkoutService(TrainingDbContext context)
        {
            _context = context;
        }

        public List<Workout> GetAll() => _context.Workouts.ToList();

        public WorkoutResponseDto? GetById(int Id)
        { //=> _context.Workouts.FirstOrDefault(w => w.Id == Id);

            var getId = _context.Workouts
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                .Include(we => we.WorkoutExercises)
                    .ThenInclude(we => we.Sets)
                .FirstOrDefault(w => w.Id == Id);


            if (getId is null)
                return null;

            return new WorkoutResponseDto
            {
                Id = getId.Id,
                Name = getId.Name,
                Date = getId.Date,
                Exercises = getId.WorkoutExercises
                        .Select(we => new ExerciseResponseDto
                        {
                            Id = we.Exercise.Id,
                            Name = we.Exercise.Name,
                        }

                        ).ToList()
            };
        }

        public Workout? CreateWorkout(CreateWorkoutDto dto)
        {

            var workout = new Workout
            {
                Name = dto.Name,
                Date = DateTime.Now
            };
            _context.Workouts.Add(workout);
            _context.SaveChanges();
            return workout;
        }


        public Workout? UpdateWorkout(int id, CreateWorkoutDto dto)
        {
            var oldWorkout = _context.Workouts.FirstOrDefault(w => w.Id == id);

            if (oldWorkout is null)
            {
                return null;
            }

            oldWorkout.Name = dto.Name;

            _context.SaveChanges();
            return oldWorkout;
        }

        public Workout? DeleteWorkout(int id)
        {
            var workout = _context.Workouts.FirstOrDefault(w => w.Id == id);
            if (workout is null)
            {
                return null;
            }
            _context.Workouts.Remove(workout);

            _context.SaveChanges();
            return workout;
        }

         public WorkoutExercise? AddExerciseToWorkout(int workoutId, AddExerciseToWorkoutDto dto)
        {
            var workout = _context.Workouts.FirstOrDefault(w => w.Id == workoutId);

            if (workout is null)
            {
                return null;
            }
            var existedWorkout = _context.WorkoutExercises.FirstOrDefault(we => we.ExerciseId == dto.ExerciseId && we.WorkoutId == workoutId);

            if (existedWorkout is null)
            {
                var exerciseToWorkout = new WorkoutExercise
                {
                    WorkoutId = workoutId,
                    ExerciseId = dto.ExerciseId
                };

                _context.WorkoutExercises.Add(exerciseToWorkout);
                _context.SaveChanges();

                return exerciseToWorkout;
            }
            else
            {
                return null;
            }
        }
    }
}