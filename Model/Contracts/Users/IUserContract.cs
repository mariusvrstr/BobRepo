using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBOB.Users
{
    public interface IUserContract
    {
        User AddUser(User user);
        User GetUserById(int userId);
        User GetUserByLoginId(string loginId);
        IEnumerable<User> GetAllUsers();
    }
}
