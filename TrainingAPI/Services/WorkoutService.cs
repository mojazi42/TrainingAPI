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

        public async Task<List<Workout>> GetAll() => await _context.Workouts.ToListAsync();

        public async  Task<WorkoutResponseDto?> GetById(int Id)
        { //=> _context.Workouts.FirstOrDefault(w => w.Id == Id);

            var getId = await _context.Workouts
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                .Include(we => we.WorkoutExercises)
                    .ThenInclude(we => we.Sets)
                .FirstOrDefaultAsync(w => w.Id == Id);


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
                            Sets = we.Sets.Select(s => new SetResponseDto
                            {
                                SetNumber = s.SetNumber,
                                RepsCount = s.RepsCount,
                                DurationSeconds = s.DurationSeconds,
                            }
                            ).ToList()
                        }

                        ).ToList(),
               
            };
        }

        public async Task<Workout?> CreateWorkout(CreateWorkoutDto dto)
        {

            var workout = new Workout
            {
                Name = dto.Name,
                Date = DateTime.Now
            };
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
            return workout;
        }


        public async Task<Workout?> UpdateWorkout(int id, CreateWorkoutDto dto)
        {
            var oldWorkout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);

            if (oldWorkout is null)
            {
                return null;
            }

            oldWorkout.Name = dto.Name;

            await _context.SaveChangesAsync();
            return oldWorkout;
        }

        public async Task<Workout?> DeleteWorkout(int id)
        {
            var workout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
            if (workout is null)
            {
                return null;
            }
            _context.Workouts.Remove(workout);

            await _context.SaveChangesAsync();
            return workout;
        }

         public async Task<WorkoutExercise?> AddExerciseToWorkout(int workoutId, AddExerciseToWorkoutDto dto)
        {
            var workout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == workoutId);

            if (workout is null)
            {
                return null;
            }
            var existedWorkout = await _context.WorkoutExercises.FirstOrDefaultAsync(we => we.ExerciseId == dto.ExerciseId && we.WorkoutId == workoutId);

            if (existedWorkout is null)
            {
                var exerciseToWorkout = new WorkoutExercise
                {
                    WorkoutId = workoutId,
                    ExerciseId = dto.ExerciseId
                };

                _context.WorkoutExercises.Add(exerciseToWorkout);
                await _context.SaveChangesAsync();

                return exerciseToWorkout;
            }
            else
            {
                return null;
            }
        }


        public async  Task<Set?> LogSet(int workoutId, int exerciseId, LogSetDto dto)
        {
            var workoutExercise = await _context.WorkoutExercises
                .FirstOrDefaultAsync(we => we.WorkoutId == workoutId && we.ExerciseId == exerciseId);

            if (workoutExercise is null)
                return null;


            var set = new Set
            {
                WorkoutExerciseId = workoutExercise.Id,
                SetNumber = dto.SetNumber,
                RepsCount = dto.RepsCount,
                DurationSeconds = dto.DurationSeconds

            };

            _context.Sets.Add(set);
            await _context.SaveChangesAsync();
            return set;
                
        }
    }
}