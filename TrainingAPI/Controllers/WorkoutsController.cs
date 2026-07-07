using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingAPI.Models;
using TrainingAPI.Services;

namespace TrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutsController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var exercises = _workoutService.GetAll();

            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var workout = _workoutService.GetById(id);

            if(workout is null)
            {
                return NotFound();
            }

            return Ok(workout);
        }


        [HttpPost]
        public IActionResult CreateWorkout([FromBody] Workout workout)
        {
            workout.Date = DateTime.Now;
            var workoutAdd = _workoutService.CreateWorkout(workout);


            return CreatedAtAction(nameof(GetById), new {id = workoutAdd.Id}, workoutAdd);


        }
    }
}
