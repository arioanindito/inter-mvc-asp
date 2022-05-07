using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace new_mvc.Models
{
    public class Course
    {
        public Course()
        {
        }

        [Key]
        public int CourseId { get; set; }
        [DisplayName("Course Name")]
        public string CourseName { get; set; }
        [DisplayName("Course Code")]
        public string CourseCode{ get; set; }
        [DisplayName("ECTS")]
        public int Credit { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
