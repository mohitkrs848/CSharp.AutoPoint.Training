using CSharp.AutoPoint.Training.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Data
{
    internal class LMSDbContext : DbContext
    {
        public LMSDbContext() : base("Server=(localdb)\\MyDemoDB;Database=SerilogDB;Integrated Security=True;")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LMSDbContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the primary key for the Users table
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            // Configure the primary key for the Courses table
            modelBuilder.Entity<Course>()
                .HasKey(c => c.Id);

            // Configure the primary key for the Enrollments table
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => e.Id);

            // Configure the relationships between the tables
            modelBuilder.Entity<Enrollment>()
                .HasRequired(e => e.Course)
                .WithMany()
                .HasForeignKey(e => e.CourseId)
                .WillCascadeOnDelete(false); // Disable cascade delete

            modelBuilder.Entity<Enrollment>()
                .HasRequired(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .WillCascadeOnDelete(false); // Disable cascade delete
        }
    }
}
