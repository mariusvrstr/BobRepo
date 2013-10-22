
namespace Services.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using JBOB.Interaction;
    using JBOB.Mapper;
    using JBOB.Users;

    public class UserService : IUserService
    {
        public User AddUser(User user)
        {
            var context = DataContextFactory.CreateContext();
            var addedUser = context.UserRepository.AddUser(user.Map());
            context.SaveChanges();

            return addedUser.Map();
        }

        public User GetUserById(int userId)
        {
            var context = DataContextFactory.CreateContext();
            var user = context.UserRepository.GetUserById(userId);

            return user.Map();
        }

        public User GetUserByLoginId(string loginId)
        {
            var context = DataContextFactory.CreateContext();
            var user = context.UserRepository.GetUserByLoginId(loginId);

            return user.Map();
        }

        public IEnumerable<User> GetAllUsers()
        {
            var context = DataContextFactory.CreateContext();
            var users = context.UserRepository.GetAllUsers();

            var mappedUsers = new List<User>();

            foreach (var user in users)
            {
                mappedUsers.Add(user.Map());
            }

            return mappedUsers;
        }
    }
}