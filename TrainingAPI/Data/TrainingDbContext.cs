using Microsoft.EntityFrameworkCore;
using TrainingAPI.Models;

namespace TrainingAPI.Data
{
    public class TrainingDbContext : DbContext
    {
        public TrainingDbContext(DbContextOptions<TrainingDbContext> options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        
    }
}
