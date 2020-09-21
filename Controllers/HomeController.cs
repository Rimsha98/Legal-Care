using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeedaniLegalCare.Controllers
{
    public class homeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Seedani LegalCare";
            return View();
        }
        public ActionResult CaseStudies()
        {
            ViewBag.Title = "Case Studies";
            return View();
        }

        public ActionResult Blog()
        {
            ViewBag.Title = "Blog";
            return View("Blog");
        }
        
        public ActionResult blogSingle()
        {
            ViewBag.Title = "Single Blog";
            return View("blogSingle");
        } 
        
        public ActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View("Contact");
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Attorneys()
        {
            return View();
        }

        public ActionResult practiceAreas()
        {
            return View();
        }

        public ActionResult practiceSingle()
        {
            return View();
        }

        public ActionResult Messages()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            return View();
        }

        public ActionResult Articles()
        {
            return View();
        }

        public ActionResult Consultation()
        {
            return View();
        }

        public ActionResult Case()
        {
            return View();
        }


        public ActionResult Something_view()
        {
            return View();
        }

        public ActionResult Register_Clients()
        {
            return View();
        }

        public ActionResult Register_Attorneys()
        {
            return View();
        }

        public ActionResult Client_Accounts()
        {
            return View();
        }

        public ActionResult Attorney_Accounts()
        {
            return View();
        }

        public ActionResult Feedback()
        {
            return View();
        }

        public ActionResult Feedback_Attorney()
        {
            return View();
        }

        public ActionResult Admins()
        {
            return View();
        }

        public ActionResult Admin_Info()
        {
            return View();
        }

        public ActionResult New_Admin()
        {
            return View();
        }

        public ActionResult SiteInfo()
        {
            return View();
        }
    }
}