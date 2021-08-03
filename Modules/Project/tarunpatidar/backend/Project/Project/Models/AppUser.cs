using Project.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public partial class AppUser
    {
        public AppUser()
        {
            Courses = new HashSet<Courses>();
            Fees = new HashSet<Fees>();
            Schedules = new HashSet<Schedule>();
            Students = new HashSet<Student>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public int? VisitedDays { get; set; }
        public int? Reputation { get; set; }
        public string GitHub { get; set; }
        public string Twitter { get; set; }
        public string Location { get; set; }
        public DateTime? LastSeen { get; set; }
        public int? ProfileViews { get; set; }
        public string AboutUser { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser applicationUser { get; set; }


        public virtual ICollection<Courses> Courses { get; set; }
        public virtual ICollection<Fees> Fees { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
