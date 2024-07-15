using CSharp.AutoPoint.Training.Data;
using CSharp.AutoPoint.Training.Interfaces;
using CSharp.AutoPoint.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public Enrollment GetEnrollmentById(int id) => _enrollmentRepository.GetEnrollmentById(id);

        public IEnumerable<Enrollment> GetAllEnrollments() => _enrollmentRepository.GetAllEnrollments();

        public void CreateEnrollment(Enrollment enrollment) => _enrollmentRepository.AddEnrollment(enrollment);

        public void UpdateEnrollment(Enrollment enrollment) => _enrollmentRepository.UpdateEnrollment(enrollment);

        public void DeleteEnrollment(int id) => _enrollmentRepository.DeleteEnrollment(id);
    }
}
