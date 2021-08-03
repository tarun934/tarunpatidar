using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public partial class Courses
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Course1 { get; set; }
        public string CourseType { get; set; }
        public string CourseDescription { get; set; }
        public int? UserId { get; set; }

        public virtual AppUser User { get; set; }
    }
}
