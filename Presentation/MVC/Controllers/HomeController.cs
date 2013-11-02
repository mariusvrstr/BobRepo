using System.Collections.Specialized;
using Antlr.Runtime.Misc;
using JBOB.Cards;
using JBOB.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using JBOB.TestData;
using JBOB.Users;
using JBOB.Web.HtmlHelpers;
using Services.Interaction;

namespace JBOB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var services = ServiceFactory.CreateUserService();

            var viewModel = new AboutViewModel
            {
               Users = services.GetAllUsers(),
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
		
		public Card Get(string Id)
        {
            var services = ServiceFactory.CreateCardService();
            var card=services.GetCardById(Id);
            return card;
        }

        public string InitData()
        {
            ObjectMother.Initialize();

            return "Object Mother Initialized";
        }

        public void AddCard(Card card)
        {
            var services = ServiceFactory.CreateCardService();
            services.AddCard(card);
            

            //return View(viewModel);
        }
    }
}
