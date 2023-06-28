using WinForms.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace WinForms
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<QuestionOneAnswer> QuestionOneAnswers { get; set; }

        public ApplicationDbContext()
        {
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"Server=localhost;Port=3306;Database=Lab;Uid=root;Pwd=PracticaRoot;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionOneAnswer>()
                .HasOne<Exam>(q => q.Exam)
                .WithMany(e => e.QuestionsOneAnswer)
                .HasForeignKey(q => q.ExamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Mark>()
                .HasOne<Applicant>(m => m.Applicant)
                .WithOne(a => a.ExamMark)
                .HasForeignKey<Mark>(m => m.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.QuestionOneAnswer)
                .WithOne(qo => qo.Question)
                .HasForeignKey<Question>(q => q.QuestionOneAnswerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.QuestionOneAnswer)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionOneAnswerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}