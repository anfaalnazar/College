using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Models
{
    public class StudentModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public int degreeid { get; set; }
        public int IsActive { get; set; }
        public DegreeModel Degree { get; set; }
        public ICollection<StudentCourse> studentcourse { get; set; }
        public ICollection<FeeRemittance> feeremittance { get; set; }

    }
}
