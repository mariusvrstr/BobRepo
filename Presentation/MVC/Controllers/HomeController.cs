using System.Collections.Generic;
using System.Web.Mvc;
using JBOB.Cards;
using JBOB.Models;
using JBOB.TestData;
using JBOB.Users;
using JBOB.Web.HtmlHelpers;

namespace JBOB.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
           // var services = ServiceFactory.CreateUserService();

            var viewModel = new AboutViewModel
            {
               Users = JsonApiConsumer.GetItems<User>(JsonApiConsumer.UserGetFull),
               Title = "First load"
            };
            
            return View(viewModel);
        }

        public JsonResult GetUserJson()
        {
            var viewModel = new AboutViewModel
            {
                Users = JsonApiConsumer.GetItems<User>(JsonApiConsumer.UserGetFull)
            };

            return this.Json(viewModel.Users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUserHtml()
        {
            var title = "Html refreshed";
            return this.PartialView("_aboutPartial", title);
        }
		
		public Card Get(int id)
		{
		    var url = string.Format("{0}/{1}", JsonApiConsumer.CardGetFull, id);
            var card = JsonApiConsumer.GetItem<Card>(url);

            return card;
        }

        public string InitData()
        {
            ObjectMother.Initialize();

            return "Object Mother Initialized";
        }

        public JsonResult AddCard(Card card)
        {
           var savedCard = JsonApiConsumer.PostJsonToApi<Card>(card, JsonApiConsumer.BaseUrl, JsonApiConsumer.CardAddPath);

           return this.Json(savedCard, JsonRequestBehavior.AllowGet);
        }
    }
}
