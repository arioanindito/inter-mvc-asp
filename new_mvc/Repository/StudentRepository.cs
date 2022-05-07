using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using new_mvc.Models;
using new_mvc.Services;

namespace new_mvc.Repository
{
    public class StudentRepository : IStudent
    {
        private DBContext db;

        public StudentRepository(DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Student> GetStudents => db.Students.Include(s => s.Faculty);

        public void Add(Student _Student)
        {
            //db.Students.Add(_Student);
            //db.SaveChanges();

            if (_Student.StudentId == 0)
            {
                db.Students.Add(_Student);
                db.SaveChanges();
            }
            else
            {
                var dbEntity = db.Students.Find(_Student.StudentId);
                //dbEntity.BorrowerId = _Loan.BorrowerId;
                //dbEntity.BookId = _Loan.BookId;
                //dbEntity.StartDate = _Loan.StartDate;
                //dbEntity.EndDate = _Loan.EndDate;
                db.SaveChanges();
            }
        }

        public Student GetStudent(int? Id)
        {
            Student dbEntity = db.Students.Include(a => a.Enrollments)
                .ThenInclude(b => b.Courses)
                .Include(c => c.Faculty)
                .SingleOrDefault(m => m.StudentId == Id);
                //.Find(Id);
            return dbEntity;
        }

        public void Remove(int? Id)
        {
            Student dbEntity = db.Students.Find(Id);
            db.Students.Remove(dbEntity);
        }
    }
}
