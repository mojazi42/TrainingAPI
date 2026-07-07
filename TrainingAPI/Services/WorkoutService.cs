using TrainingAPI.Data;
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

        public Workout? GetById(int Id) => _context.Workouts.FirstOrDefault(w => w.Id == Id);

        public Workout? CreateWorkout(Workout workout)
        {
            _context.Workouts.Add(workout);
            _context.SaveChanges();
            return workout;
        }
    }
}
