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

        public Workout? GetById(int Id)
        { //=> _context.Workouts.FirstOrDefault(w => w.Id == Id);
            var getId = _context.Workouts
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                .Include(we => we.WorkoutExercises)
                    .ThenInclude(we => we.Sets)

                .FirstOrDefault(w => w.Id == Id);

            return getId;
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


        public Workout? UpdateWorkout(int id, Workout workout)
        {
            var oldWorkout = _context.Workouts.FirstOrDefault(w => w.Id == id);

            if (oldWorkout is null)
            {
                return null;
            }

            oldWorkout.Name = workout.Name;

            _context.SaveChanges();
            return oldWorkout;
        }

        public Workout? DeleteWorkout(int id)
        {
            var workout = _context.Workouts.FirstOrDefault(w => w.Id == id);

            _context.Workouts.Remove(workout);

            _context.SaveChanges();
            return workout;
        } 
        
    }
}
