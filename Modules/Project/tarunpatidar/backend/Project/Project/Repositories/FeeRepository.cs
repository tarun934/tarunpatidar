using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Repositories.Interface;

namespace Project.Repositories
{
    public class FeeRepository : GenericRepository<Fees> , IFeeRepository
    {
        public FeeRepository(UdemyDBContext context) : base(context)
        {

        }
    }
}
