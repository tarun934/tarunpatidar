using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public partial class Schedule
    {
        public int SchID { get; set; }
        public int? UserId { get; set; }
        public string SchName { get; set; }
        public int SchTime { get; set; }
        public string SchDescription { get; set; }
        public DateTime SchDate { get; set; }

        public virtual AppUser User { get; set; }
    }
}
