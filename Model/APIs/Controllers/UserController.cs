using System.Collections.Generic;
using System.Web.Http;
using JBOB.API.Interaction;
using JBOB.Users;

namespace JBOB.API.Controllers
{
    public class UserController : ApiController
    {

        // GET api/user
        public IEnumerable<User> Get()
        {
            var userService = ServiceFactory.CreateUserService();
            var users = userService.GetAllUsers();

            return users;
        }

        // GET api/user/5
        public User Get(int id)
        {
            var userService = ServiceFactory.CreateUserService();
            var user = userService.GetUserById(id);

            return user;
        }

        // POST api/user
        public User Add([FromBody]User user)
        {
            if (user == null) return null;

            var userService = ServiceFactory.CreateUserService();
            return userService.AddUser(user);
        }

     /*   // PUT api/user/5
        public void Update(int id, [FromBody]User user)
        {
        } */

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
