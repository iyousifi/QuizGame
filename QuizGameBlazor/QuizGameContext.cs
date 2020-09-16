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
        public DbSet<QuestionTags> QuestionTags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnswerOption>().HasKey(ao => new {ao.AnswerId, ao.QuestionId});
            modelBuilder.Entity<AnswerOption>()
                .HasOne<Question>(q => q.Question)
                .WithMany(ao => ao.AnswerOptions)
                .HasForeignKey(a => a.QuestionId);
            
            modelBuilder.Entity<AnswerOption>()
                .HasOne<Answer>(a => a.Answer)
                .WithMany(ao => ao.AnswerOptions)
                .HasForeignKey(q => q.AnswerId);

            modelBuilder.Entity<AnswerTags>().HasKey(at => new {at.AnswerId, at.TagId});
            modelBuilder.Entity<AnswerTags>()
                .HasOne<Answer>(a => a.Answer)
                .WithMany(at => at.Tags)
                .HasForeignKey(t => t.TagId);

            modelBuilder.Entity<AnswerTags>()
                .HasOne<Tag>(t => t.Tag)
                .WithMany(at => at.AnswerTags)
                .HasForeignKey(at => at.AnswerId);

            modelBuilder.Entity<QuestionTags>().HasKey(qt => new {qt.QuestionId, qt.TagId});
            modelBuilder.Entity<QuestionTags>()
                .HasOne<Question>(a => a.Question)
                .WithMany(at => at.QuestionTags)
                .HasForeignKey(t => t.QuestionId);

            modelBuilder.Entity<QuestionTags>()
                .HasOne<Tag>(t => t.Tag)
                .WithMany(at => at.QuestionTags)
                .HasForeignKey(at => at.TagId);




        }
    }
}
