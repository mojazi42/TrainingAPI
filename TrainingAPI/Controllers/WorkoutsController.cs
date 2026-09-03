using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingAPI.DTOs;
using TrainingAPI.Models;
using TrainingAPI.Services;

namespace TrainingAPI.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetAll()
        {
            var exercises = await _workoutService.GetAll();

            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var workout = await _workoutService.GetById(id);

            if(workout is null)
            {
                return NotFound();
            }

            return Ok(workout);
        }


        [HttpPost]
        public async Task<IActionResult> CreateWorkout([FromBody] CreateWorkoutDto dto)
        {
            //workout.Date = DateTime.Now;
            var workoutAdd = await _workoutService.CreateWorkout(dto);
            if (workoutAdd is null)
                return NotFound();

            

            return CreatedAtAction(nameof(GetById), new {id = workoutAdd.Id}, workoutAdd);


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkout(int id, [FromBody] CreateWorkoutDto dto)
        {
            var exercise = await _workoutService.UpdateWorkout(id, dto);

            if(exercise is null)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            var exercise = await _workoutService.DeleteWorkout(id);

            if(exercise is null)
            {
                return NotFound();
            }

            return NoContent();

        }





        [HttpPost("{workoutId}/exercises")]
        public async Task<IActionResult> AddWorkoutToExercise(int workoutId,[FromBody] AddExerciseToWorkoutDto dto)
        {
            //workout.Date = DateTime.Now;
            //var workout = _workoutService.GetById(workoutId);
            

            var addExerciseToWorkout = await _workoutService.AddExerciseToWorkout(workoutId, dto);
            if (addExerciseToWorkout is null)
                return NotFound();

            //var workoutAdd = _workoutService.CreateWorkout(dto);
            return Ok(addExerciseToWorkout);
        }



        [HttpPost("{workoutId}/exercises/{exerciseId}/sets")]
        public async Task<IActionResult> AddSet(int workoutId, int exerciseId, [FromBody] LogSetDto dto)
        {
            var addSet = await _workoutService.LogSet(workoutId, exerciseId, dto);
            if (addSet is null)
                return NotFound();

            return Ok(addSet);
        }
       
    }
}
