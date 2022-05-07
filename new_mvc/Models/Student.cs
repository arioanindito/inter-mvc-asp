using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace new_mvc.Models
{
    public enum Gender
    {
        Male, Female
    }
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Gender? Gender { get; set; }
        [DisplayName("Faculty")]
        public int FacultyId { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public Faculty Faculty { get; set; }
    }
}