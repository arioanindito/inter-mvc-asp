using System;
using System.Collections.Generic;
using new_mvc.Models;

namespace new_mvc.Services
{
    public interface ICourse
    {
        IEnumerable<Course> GetCourses { get; }

        Course GetCourse(int Id);
        void Add(Course _Course);
        void Remove(int Id);
    }
}
