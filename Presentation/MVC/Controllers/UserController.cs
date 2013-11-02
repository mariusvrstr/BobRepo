using System.Collections.Generic;
using System.Web.Http;
using JBOB.Users;
using Services.Interaction;

namespace JBOB.Controllers
{
    public class UserController : ApiController
    {

        /* Exception: throw new HttpResponseException(HttpStatusCode.BadRequest)
         * http://localhost:1079/api/User
         * 
         * JsonResult / return this.Json(partialAboutBoxJson, JsonRequestBehavior.AllowGet);
         * 
         * 
         * 
         * 
         * */



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
            var userService = ServiceFactory.CreateUserService();
            var addedUser = userService.AddUser(user);

            return addedUser;

        }

        // PUT api/user/5
        public void Update(int id, [FromBody]User user)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
