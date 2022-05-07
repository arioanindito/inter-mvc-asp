using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace new_mvc.Models
{
    public enum Year
    {
        [Display(Name ="First Year")]
        First,
        [Display(Name = "Second Year")]
        Second,
        [Display(Name ="Third Year")]
        Third
    }

    public class Enrollment
    {
        public Enrollment()
        {
        }

        [Key]
        public int EnrollmentId { get; set; }
        [DisplayName("Student Name")]
        public int StudentId { get; set; }
        [DisplayName("Course Name")]
        public int CourseId { get; set; }
        [DisplayName("Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
        [DisplayName("Year of Study")]
        public Year? Year { get; set; }

        [DisplayName("Student Name")]
        public Student Students { get; set; }
        [DisplayName("Course Name")]
        public Course Courses { get; set; }
    }
}
