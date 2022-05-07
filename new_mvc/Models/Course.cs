using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace new_mvc.Models
{
    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }

        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode{ get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
