using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public partial class Student
    {
        public int StuID { get; set; }
        public int? UserId { get; set; }
        public string StuName { get; set; }
        public int StuMobile { get; set; }
        public string StuEmail { get; set; }
        public string StuAddress { get; set; }

        public virtual AppUser User { get; set; }
    }
}
