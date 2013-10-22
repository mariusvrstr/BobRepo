
namespace Services.ServiceStubs
{
    using System.Collections.Generic;
    using JBOB.Mapper;
    using JBOB.TestData;
    using JBOB.Users;

    public class UserServiceStub : IUserService
    {

        public User AddUser(User user)
        {
            return user;
        }

        public User GetUserById(int userId)
        {
            return ObjectMother.Users.Fred.Map();
        }

        public User GetUserByLoginId(string loginId)
        {
            return ObjectMother.Users.Fred.Map();
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>
            {
                ObjectMother.Users.Fred.Map(),
                ObjectMother.Users.Chow.Map()
            };

            return users;
        }
    }
}