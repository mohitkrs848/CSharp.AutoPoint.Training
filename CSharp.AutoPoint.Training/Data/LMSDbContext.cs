using CSharp.AutoPoint.Training.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CSharp.AutoPoint.Training.Data
{
    public class LMSDbContext : DbContext
    {
        public LMSDbContext() : base("Server=(localdb)\\MyDemoDB;Database=LMSdb;Integrated Security=True;")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LMSDbContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the primary key for the Users table
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id)
                .HasMany(u => u.Enrollments);

            // Configure the primary key for the Courses table
            modelBuilder.Entity<Course>()
                .HasKey(c => c.Id)
                .HasMany(c => c.Enrollments);                

            // Configure the relationships between the tables
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => e.Id)
                .HasRequired(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .WillCascadeOnDelete(false); // Disable cascade delete

            modelBuilder.Entity<Enrollment>()
                .HasRequired(e => e.Student)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .WillCascadeOnDelete(false); // Disable cascade delete
        }
    }
}
