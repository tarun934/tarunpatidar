using Project.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UnitOfWorkPattern
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository AppUsers { get; }
        ICourseRepository Courses { get; }
        IFeeRepository Fees { get; }
        IScheduleRepository Schedule { get; }
        IStudentRepository Student { get; }


        int Complete();
    }
}