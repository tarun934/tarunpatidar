using Project.Models;
using Project.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(UdemyDBContext context) : base(context)
        {

        }
    }
}
