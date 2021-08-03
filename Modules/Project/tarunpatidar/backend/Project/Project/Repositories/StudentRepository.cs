using Project.Models;
using Project.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(UdemyDBContext context) : base(context)
        {

        }
    }
}
