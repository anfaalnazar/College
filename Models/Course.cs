using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace College.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [MaxLength(50)]
        [MinLength(3)]
        [Required]
        public string CourseName { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int Fees { get; set; }

        public bool Is_Active { get; set; } = true;

        public ICollection<StudentCourse> studentcourse { get; set; }
    }
}
