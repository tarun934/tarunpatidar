using Project.Repositories;
using Project.Models;
using Project.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UdemyDBContext _context;

        public UnitOfWork(UdemyDBContext context)
        {
            _context = context;
            AppUsers = new UserRepository(context);
            Courses = new CourseRepository(context);
            Fees = new FeeRepository(context);
            Schedule = new ScheduleRepository(context);
            Student = new StudentRepository(context);
        }

        public IUserRepository AppUsers { get; private set; }
        public ICourseRepository Courses { get; private set; }
        public IFeeRepository Fees { get; private set; }  
        public IScheduleRepository Schedule { get; private set; }
        public IStudentRepository Student { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}