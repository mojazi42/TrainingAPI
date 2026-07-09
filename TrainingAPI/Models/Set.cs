namespace TrainingAPI.Models
{
    public class Set
    {
        public int Id { get; set; }
        public int WorkoutExerciseId { get; set; }
        public int SetNumber { get; set; }
        public int? RepsCount {  get; set; }
        public int? DurationSeconds {  get; set; }
        public WorkoutExercise WorkoutExercise { get; set; } = null!;
    }
}
