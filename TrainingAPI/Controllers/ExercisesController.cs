using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingAPI.Data;
using TrainingAPI.Models;

namespace TrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {

        //public static readonly List<Exercise> exercises = new()
        //{
        //    new Exercise {
        //        Id = 1, Name = "Knee Push Ups",
        //        MetricType = MetricType.Reps,
        //        RepsCount = 12
        //    } ,

        //    new Exercise {
        //        Id = 2, Name = "Asturalina Pull ups",
        //        MetricType = MetricType.Reps,
        //        RepsCount = 8
        //    },
        //    new Exercise {
        //        Id = 3, Name = "Plank",
        //        MetricType = MetricType.Duration,
        //        DurationSeconds = 60
        //    },

        //};


        private readonly TrainingDbContext _context;

        public ExercisesController(TrainingDbContext context)
        {
            _context =  context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var exercises = _context.Exercises;// the way when using database

            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //var exercise = exercises.FirstOrDefault(e => e.Id == id); when using list in memory
            var exercise = _context.Exercises.FirstOrDefault(e => e.Id == id); // when using the database

            if (exercise is null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        [HttpPost]
        public IActionResult CreateExercise([FromBody] Exercise exercise)
        {
            // When using the list in memory
/*            int newId = exercises.Count == 0 ? 1 : exercises.Max(e => e.Id) + 1;
            exercise.Id = newId;
            exercises.Add(exercise);*/


            //When using database
            _context.Exercises.Add(exercise);
            _context.SaveChanges();




            return CreatedAtAction(nameof(GetById), new { id = exercise.Id }, exercise);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateExercise(int id, [FromBody] Exercise updateExercises)
        {

            var exercise = _context.Exercises.FirstOrDefault(e => e.Id == id);

            if (exercise is null)
            {
                return NotFound();
            }

            exercise.Name = updateExercises.Name;
            exercise.MetricType = updateExercises.MetricType;
            exercise.RepsCount = updateExercises.RepsCount;
            exercise.DurationSeconds = updateExercises.DurationSeconds;

            _context.SaveChanges();


            return NoContent();


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteExercise(int id)
        {
            var exercise = _context.Exercises.FirstOrDefault(e => e.Id == id);

            if(exercise is null)
            {
                return NotFound();
            }

            _context.Exercises.Remove(exercise);
            _context.SaveChanges();


            return NoContent();

        }
    }
}
