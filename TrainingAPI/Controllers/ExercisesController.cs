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
                MatricType = MatricType.Reps,
                RepsCount = 12
            } ,

            new Exercise { 
                Id = 2, Name = "Asturalina Pull ups",
                MatricType = MatricType.Reps,
                RepsCount = 8
            },
            new Exercise {
                Id = 3, Name = "Plank",
                MatricType = MatricType.Duration,
                DurationSeconds = 60
            },

        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(exercises);
        }
    }
}
