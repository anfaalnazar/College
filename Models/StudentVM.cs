using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Models
{
    public class StudentVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public int degreeid { get; set; }
        public string degreename { get; set; }
        public int[] CourseIds { get; set; }
        public int IsActive { get; set; }
    }
}

