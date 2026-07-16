
namespace TrainingAPI.DTOs
{
    public class WorkoutResponseDto
    {
        public int Id {get ; set; }
        public string Name {get ; set; } = string.Empty;
        public DateTime Date { get ; set; }
        public List<ExerciseResponseDto> Exercises { get; set; } = new();
    }
}
