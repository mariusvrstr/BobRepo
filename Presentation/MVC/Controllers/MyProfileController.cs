using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JBOB.Controllers
{
    public class MyProfileController : Controller
    {
        //
        // GET: /MyProfile/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /MyProfile/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        
        //
        // POST: /MyProfile/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        //
        // POST: /MyProfile/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
    }
}
