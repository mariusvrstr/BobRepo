using System.Collections.Specialized;
using Antlr.Runtime.Misc;
using JBOB.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using JBOB.Users;
using JBOB.Web.HtmlHelpers;

namespace JBOB.Controllers
{
    public class HomeController : Controller
    {
        #region Stub Data

        /*

        private List<User> userSetA = new List<User> 
        {
            new User
            {
                UserId = 1,
                Id = "john123",
                Login = "John",
                Name = "John",
                Password = "john123",
                Roles = new List<UserRoleEnum>
                {
                    UserRoleEnum.Admin,
                    UserRoleEnum.HR
                },
                Surname= "Johnson"
            },
                new User
            {
                UserId = 2,
                Id = "peter123",
                Login = "Peter",
                Name = "Peter",
                Password = "john123",
                Roles = new List<UserRoleEnum>
                {
                    UserRoleEnum.Admin,
                    UserRoleEnum.HR
                },
                Surname= "Wilkerson"
            }
        };

        private List<User> userSetB = new List<User> 
        {
            new User
            {
                UserId = 1,
                Id = "sandra123",
                Login = "Sandra",
                Name = "Sandra",
                Password = "sandra123",
                Roles = new List<UserRoleEnum>
                {
                    UserRoleEnum.Admin,
                    UserRoleEnum.HR
                },
                Surname= "Pillay"
            },
            new User
            {
                UserId = 2,
                Id = "rista123",
                Login = "Rista",
                Name = "Rista",
                Password = "rista123",
                Roles = new List<UserRoleEnum>
                {
                    UserRoleEnum.Admin,
                    UserRoleEnum.HR
                },
                Surname= "Peters"
            },
            new User
            {
                UserId = 2,
                Id = "christel123",
                Login = "Christel",
                Name = "Christel",
                Password = "christel123",
                Roles = new List<UserRoleEnum>
                {
                    UserRoleEnum.Admin,
                    UserRoleEnum.HR
                },
                Surname= "Jones"
            }
        }; */

        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var user = new User()
            {
                Login = "Test",
                Password = "Test",
                Name = "Test",
                Surname = "Surname"
            };

           // var response = JsonApiConsumer.GetItemWithPost<User>(user, JsonApiConsumer.UserAdd);

            var viewModel = new AboutViewModel
            {
               Users = JsonApiConsumer.GetItems<User>(JsonApiConsumer.UserGetAll),
               Title = "First load"
            };
            
            return View(viewModel);
        }

        public JsonResult GetUserJson()
        {
            var viewModel = new AboutViewModel
            {
             //   Users = userSetB
            };

            return this.Json(viewModel.Users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUserHtml()
        {
            var title = "Html refreshed";

            return this.PartialView("_aboutPartial", title);
        }
    }
}
