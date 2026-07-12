using System.ComponentModel.DataAnnotations;

namespace TrainingAPI.DTOs
{
    public class CreateWorkoutDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
