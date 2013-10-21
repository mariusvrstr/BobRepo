using System.Linq;
using JBOB.Entities;
using JBOB.Repositories;

// ReSharper disable CheckNamespace
namespace JBOB
// ReSharper restore CheckNamespace
{
    internal partial class DataContext : IUserRepository
    {
        public User AddUser(User user)
        {
           var contextUser = this.Users.Add(user);

           return contextUser;
        }

        public User GetUserById(int userId)
        {
            var contextUser = Queryable.FirstOrDefault<User>((from thisUser in this.Users
                    where thisUser.UserId == userId
                    select thisUser));

            return contextUser;
        }

        public User GetUserByLoginId(string loginId)
        {
            var contextUser = Queryable.FirstOrDefault<User>((from thisUser in this.Users
                                   where thisUser.Login == loginId
                                   select thisUser));

            return contextUser;
        }

        public IQueryable<User> GetAllUsers()
        {
            return Queryable.Select<User, User>(this.Users, thisUser => thisUser);
        }

        public void DeleteAllUsers()
        {
            var users = this.GetAllUsers();

            foreach (var user in users.Where(user => user != null))
            {
                this.Users.Remove(user);
            }
        }
    }
}
