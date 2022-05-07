using System;
using System.Collections.Generic;
using new_mvc.Models;
using new_mvc.Services;

namespace new_mvc.Repository
{
    public class CourseRepository : ICourse
    {
        private DBContext db;

        public CourseRepository(DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Course> GetCourses => db.Courses;

        public void Add(Course _Course)
        {
            db.Courses.Add(_Course);
            db.SaveChanges();
        }

        public Course GetCourse(int Id)
        {
            Course dbEntity = db.Courses.Find(Id);
            return dbEntity;
        }

        public void Remove(int Id)
        {
            Course dbEntity = db.Courses.Find(Id);
            db.Courses.Remove(dbEntity);
        }
    }
}
