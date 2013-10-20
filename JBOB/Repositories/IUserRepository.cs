using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JBOB.Entities;

namespace JBOB.Repositories
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUserById(int userId);
        User GetUserByLoginId(string loginId);
        IQueryable<User> GetAllUsers();
    }
}
