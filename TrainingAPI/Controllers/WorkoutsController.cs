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

        [HttpPut("{id}")]
        public IActionResult UpdateWorkout(int id, [FromBody] Workout workout)
        {
            var exercise = _workoutService.UpdateWorkout(id, workout);

            if(exercise is null)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteWorkout(int id)
        {
            var exercise = _workoutService.DeleteWorkout(id);

            if(exercise is null)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
