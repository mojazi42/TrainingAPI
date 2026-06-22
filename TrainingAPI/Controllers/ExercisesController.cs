using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingAPI.Models;

namespace TrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {

        public static readonly List<Exercise> exercises = new()
        {
            new Exercise {
                Id = 1, Name = "Knee Push Ups",
                MetricType = MetricType.Reps,
                RepsCount = 12
            } ,

            new Exercise {
                Id = 2, Name = "Asturalina Pull ups",
                MetricType = MetricType.Reps,
                RepsCount = 8
            },
            new Exercise {
                Id = 3, Name = "Plank",
                MetricType = MetricType.Duration,
                DurationSeconds = 60
            },

        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var exercise = exercises.FirstOrDefault(e => e.Id == id);

            if(exercise is null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        [HttpPost]
        public IActionResult CreateExercise([FromBody] Exercise exercise)
        {
            exercises.Add(exercise);
            return CreatedAtAction(nameof(GetById), new { id = exercise.Id }, exercise);
        }
    }
}
