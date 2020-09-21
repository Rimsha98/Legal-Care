using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeedaniLegalCare.Controllers
{
    public class messagesController : Controller
    {
        // GET: messages
        public ActionResult chat()
        {
            return View();
        }
    }
}