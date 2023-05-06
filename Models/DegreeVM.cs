using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Models
{
    public class DegreeVM
    {
        public int degreeid { get; set; }
        public string degreename { get; set; }
        public string shortform { get; set; }
        public string category { get; set; }
        public int IsActive { get; set; }
    }
}
