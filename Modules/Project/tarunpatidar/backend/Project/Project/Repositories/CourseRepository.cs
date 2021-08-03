using Project.Models;
using Project.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Project.Repositories
{
    public class CourseRepository : GenericRepository<Courses>, ICourseRepository
    {
        private readonly UdemyDBContext context;
        public CourseRepository(UdemyDBContext context) : base(context)
        {
            this.context = context;
        }

        public void UpdateCourses(int CorsId , Courses Cors)
        {
            Cors.CourseId = CorsId;
            _context.Update(Cors);
        }
        
        public bool ValidateUserCourse(int userId , int corsId)
        {
            var Cors = _context.Courses.AsNoTracking().Where(c => c.CourseId == corsId).ToList()[0];

            if (Cors == null || Cors.UserId != userId)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Courses> GetAllCourses()
        {
            var cors = _context.Courses
                .AsEnumerable();
            return cors;
        }

        public IEnumerable<object> FindCourses(string corsPart)
        {
            var courses = context.Courses.Where(c => c.Course1.Contains(corsPart.Trim())).AsEnumerable();
            return courses;
        }
    }
}
