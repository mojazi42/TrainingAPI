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
        public string Name { get; set; } = string.Empty;

        //Which type of metric = Reps or Duration
        public MetricType MetricType { get; set; }

        public int? RepsCount { get; set; }
        public int? DurationSeconds { get; set; }
    }
}
