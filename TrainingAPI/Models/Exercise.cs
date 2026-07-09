using System.ComponentModel.DataAnnotations;

namespace TrainingAPI.Models
{

    public enum MetricType
    {
        Reps,
        Duration
    }


    public class Exercise
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        //Which type of metric = Reps or Duration
        [Required]
        public MetricType MetricType { get; set; }

       
        public int? RepsCount { get; set; }

        
        public int? DurationSeconds { get; set; }

        public List<WorkoutExercise> WorkoutExercises { get; set; } = new();
    }
}
