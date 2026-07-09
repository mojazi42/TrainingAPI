using System.ComponentModel.DataAnnotations;

namespace TrainingAPI.Models
{
    public class Workout
    {
       public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public  string Name { get; set; } = string.Empty;


        public DateTime Date { get; set; }

        public List<WorkoutExercise> WorkoutExercises { get; set; } = new();


    }
}
