using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace College.Models
{
    public class DegreeModel
    {
        [Key]
        public int degreeid { get; set; }
        public string degreename { get; set; }
        public int IsActive { get; set; }
        public ICollection<StudentModel> Students { get; set; }
    }
}

