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
    public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
    {

        public EnrollmentRepository(LMSDbContext context) : base(context)
        {
        }

        public Enrollment GetEnrollmentById(int id) => GetById(id);

        public IEnumerable<Enrollment> GetAllEnrollments() => GetAll();

        public void AddEnrollment(Enrollment enrollment)=> Add(enrollment);

        public void UpdateEnrollment(Enrollment enrollment) => Update(enrollment);

        public void DeleteEnrollment(int id) => Delete(GetById(id));
    }
}
