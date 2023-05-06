using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace College.Models
{
    public class StudentCourse
    {
        [Key]
        public int StudentCourseId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public StudentModel student { get; set; }
        public Course course { get; set; }

        // public ICollection<Fees> fees { get; set; }
        public bool Is_Active { get; set; } = true;
    }
}
