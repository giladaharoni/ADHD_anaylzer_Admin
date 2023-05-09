using Microsoft.EntityFrameworkCore;
namespace ADHD_anaylzer_Admin.Models
{
    public class myDBContext : DbContext
    {

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<ProcessedData> Datas { get; set; } = null!;
        public DbSet<QuizAnswer> Answers { get; set; } = null!;


        public myDBContext(DbContextOptions<myDBContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.UserName);
            modelBuilder.Entity<ProcessedData>().HasKey(e => new { e.SessionId, e.Timestamp });
            modelBuilder.Entity<QuizAnswer>().HasKey(e => new {e.AnswerByUserName,e.QuestionNumber});
        }
    }
}
