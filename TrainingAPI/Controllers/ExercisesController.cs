using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingAPI.Data;
using TrainingAPI.DTOs;
using TrainingAPI.Models;
using TrainingAPI.Services;

namespace TrainingAPI.Controllers
{

    [Authorize]
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


        private readonly IExerciseService _exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            var exercises = await _exerciseService.GetAll();// the way when using database

            return Ok(exercises);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var exercise = exercises.FirstOrDefault(e => e.Id == id); when using list in memory
            var exercise = await _exerciseService.GetById(id); // when using the database

            if (exercise is null)
            {
                return NotFound();
            }

            return Ok(exercise); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateExercise([FromBody] CreateExerciseDto dto)
        {
            // When using the list in memory
            /*            int newId = exercises.Count == 0 ? 1 : exercises.Max(e => e.Id) + 1;
                        exercise.Id = newId;
                        exercises.Add(exercise);*/


            //When using database without service layer
            //_context.Exercises.Add(exercise);
            //_context.SaveChanges();
         

            var exerciseAdd = await _exerciseService.CreateExercise(dto);

            if(exerciseAdd is null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = exerciseAdd.Id }, exerciseAdd);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExercise(int id, [FromBody] CreateExerciseDto updateExercises)
        {

            var exercise = await _exerciseService.UpdateExercise(id, updateExercises);

            if (exercise is null)
            {
                return NotFound();
            }

            //When use update from the data layer dircetly
            //exercise.Name = updateExercises.Name;
            //exercise.MetricType = updateExercises.MetricType;
            //exercise.RepsCount = updateExercises.RepsCount;
            //exercise.DurationSeconds = updateExercises.DurationSeconds;

            //_context.SaveChanges();

            return NoContent();


        }

        [HttpDelete("{id}")]
        public async  Task<IActionResult> DeleteExercise(int id)
        {
            var exercise = await _exerciseService.DeleteExercise(id) ;

            if (exercise is null)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}

    
