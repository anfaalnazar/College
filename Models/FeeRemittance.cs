using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace College.Models
{
    public class FeeRemittance
    {
        public int FeeRemittanceId { get; set; }
        [ForeignKey("StudentModel")]
        public int studentid { get; set; }
        public int CourseId { get; set; }
        public StudentModel student { get; set; }
        public Course course { get; set; }
        public int totalpaid { get; set; } 
        public int remaining { get; set; }
        public int nowpaying { get; set; }

    }
}
