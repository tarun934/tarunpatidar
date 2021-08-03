using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories.Interface
{
    public interface ICourseRepository : IGenericRepository<Courses>
    {
        public bool ValidateUserCourse(int userId, int corsId);
        public void UpdateCourses(int corsId, Courses Cors);
        public IEnumerable<Courses> GetAllCourses();
        public IEnumerable<object> FindCourses(string corsPart);
    }
}
