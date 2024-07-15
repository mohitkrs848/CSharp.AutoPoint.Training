using CSharp.AutoPoint.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Data
{
    public interface IEnrollmentRepository
    {
        Enrollment GetEnrollmentById(int id);
        IEnumerable<Enrollment> GetAllEnrollments();
        void AddEnrollment(Enrollment enrollment);
        void UpdateEnrollment(Enrollment enrollment);
        void DeleteEnrollment(int id);
    }
}
