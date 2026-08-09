namespace TrainingAPI.DTOs
{
    public class ExerciseResponseDto
    {
        public  int Id { get; set; }
        public string Name { get; set; }

        public List<SetResponseDto> Sets { get; set; } = new();
    }
}
