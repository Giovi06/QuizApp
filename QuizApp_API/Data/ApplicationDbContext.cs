using Microsoft.EntityFrameworkCore;
using QuizApp_API.Models;

namespace QuizApp_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
    }
}