using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeedaniLegalCare.Controllers{
    public class adminsController : Controller{
        
        public ActionResult all_admins(){
            ViewBag.LinkText = "admins";
            return View();
        }

        public ActionResult new_admin(){
            ViewBag.LinkText = "admins";
            return View();
        }

        public ActionResult admin(){
            ViewBag.LinkText = "admins";
            return View();
        }

        public ActionResult settings(){
            ViewBag.LinkText = "admins";
            return View();
        }
    }
}