using TrainingAPI.Data;
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

        public List<Exercise> GetAll() => _context.Exercises.ToList();


        public Exercise? GetById(int Id) => _context.Exercises.FirstOrDefault(e => e.Id == Id);

        public Exercise? CreateExercise(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            _context.SaveChanges();
            return exercise;
        }
    }
}
