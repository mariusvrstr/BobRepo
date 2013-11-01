using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JBOB.TestData;

namespace Services.Controllers
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
