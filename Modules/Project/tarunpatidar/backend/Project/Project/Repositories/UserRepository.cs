using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Project.Models.Authentication;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class UserRepository : GenericRepository<AppUser> , IUserRepository
    {
        private readonly UdemyDBContext context;
        public UserRepository(UdemyDBContext context) : base(context)
        {
            this.context = context;
        }

        public void UpdateUser(int id , AppUser user)
        {
            user.UserId = id;

            context.AppUsers.Update(user);
        }

        public bool ValidateUser(string cred, int id)
        {
            var user = this.context.AppUsers.AsNoTracking().SingleOrDefault(x => x.UserId == id);
            if (user == null || user.ApplicationUserId != cred)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<AppUser> SearchUser(string user)
        {
            var users = context.AppUsers.Where(u => u.FullName.Contains(user.Trim())).AsEnumerable();
            return users;
        }
    }
}
