using CSharp.AutoPoint.Training.Data;
using CSharp.AutoPoint.Training.Interfaces;
using CSharp.AutoPoint.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Repositories
{
    internal class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly LMSDbContext _context;

        public EnrollmentRepository(LMSDbContext context)
        {
            _context = context;
        }

        public Enrollment GetEnrollmentById(int id) => _context.Enrollments.Find(id);

        public IEnumerable<Enrollment> GetAllEnrollments() => _context.Enrollments.ToList();

        public void AddEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            var existingEnrollment = GetEnrollmentById(enrollment.Id);
            if (existingEnrollment != null)
            {
                existingEnrollment.CourseId = enrollment.CourseId;
                existingEnrollment.StudentId = enrollment.StudentId;
                _context.SaveChanges();
            }
        }

        public void DeleteEnrollment(int id)
        {
            var enrollment = GetEnrollmentById(id);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                _context.SaveChanges();
            }
        }
    }
}
