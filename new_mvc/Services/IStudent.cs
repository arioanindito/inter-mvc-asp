using System;
using System.Collections.Generic;
using new_mvc.Models;

namespace new_mvc.Services
{
    public interface IStudent
    {
        IEnumerable<Student> GetStudents { get; }

        Student GetStudent(int? Id);
        void Add(Student _Student);
        void Remove(int? Id);
    }
}
