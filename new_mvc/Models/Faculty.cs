using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace new_mvc.Models
{
    public class Faculty
    {
        public Faculty()
        {
        }

        [Key]
        public int FacultyId { get; set; }
        [DisplayName("Faculty Name")]
        public string FacultyName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
