using TrainingAPI.Models;

namespace TrainingAPI.DTOs
{
    
    public class ExerciseDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public MetricType MetricType { get; set; }

        public int? RepsCount { get; set; }

        public int? DurationSeconds { get; set; }
    }
}
