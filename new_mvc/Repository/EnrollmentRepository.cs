using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using new_mvc.Models;
using new_mvc.Services;

namespace new_mvc.Repository
{
    public class EnrollmentRepository : IEnrollment
    {
        private DBContext db;

        public EnrollmentRepository(DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Enrollment> GetEnrollments => db.Enrollments.Include(s => s.Courses).Include(a => a.Students);

        public void Add(Enrollment _Enrollment)
        {
            db.Enrollments.Add(_Enrollment);
            db.SaveChanges();
        }

        public Enrollment GetEnrollment(int? Id)
        {
            Enrollment dbEntitiy = db.Enrollments.Find(Id);
            return dbEntitiy;
        }

        public void Remove(int? Id)
        {
            Enrollment dbEntity = db.Enrollments.Find(Id);
            db.Enrollments.Remove(dbEntity);
        }
    }
}
