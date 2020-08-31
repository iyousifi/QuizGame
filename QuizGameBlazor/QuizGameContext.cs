using Microsoft.EntityFrameworkCore;
using QuizGameBlazor.Models;

namespace QuizGameBlazor
{
    public class QuizGameContext : DbContext
    {
        public QuizGameContext(DbContextOptions<QuizGameContext> options) : base(options)
        {

        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<AnswerTags> AnswerTags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnswerOption>().HasKey(ao => new { ao.AnswerId, ao.QuestionId });
            modelBuilder.Entity<AnswerTags>().HasKey(at => new { at.AnswerId, at.TagId });


        }
    }
}
