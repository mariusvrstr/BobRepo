using System.Web.Mvc;
using JBOB.TestData;

namespace JBOB.API.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public string InitData()
        {
            ObjectMother.Initialize();

            return "Onject Mother Initialized";
        }

    }
}
