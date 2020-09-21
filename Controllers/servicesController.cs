using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeedaniLegalCare.Controllers
{
    public class servicesController : Controller
    {
        // GET: services
        public ActionResult practice_areas()
        {
            return View();
        }

        public ActionResult practice_area()
        {
            return View();
        }

        public ActionResult attorneys()
        {
            return View();
        }

        public ActionResult attorney()
        {
            return View();
        }

        public ActionResult website_settings()
        {
            ViewBag.LinkText = "webinfo";
            return View();
        }
    }
}