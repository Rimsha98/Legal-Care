using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeedaniLegalCare.Controllers
{
    public class consultationController : Controller
    {
        // GET: consultation
        public ActionResult all_messages()
        {
            ViewBag.LinkText = "consultation";
            return View();
        }

        public ActionResult view_consultation()
        {
            ViewBag.LinkText = "consultation";
            return View();
        }

        public ActionResult free_consultation()
        {
            ViewBag.LinkText = "consultation";
            return View();
        }

        public ActionResult message()
        {
            ViewBag.LinkText = "consultation";
            return View();
        }

        public ActionResult write_response()
        {
            ViewBag.LinkText = "consultation";
            return View();
        }
    }
}