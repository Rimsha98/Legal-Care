using SeedaniLegalCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeedaniLegalCare.Controllers{
    public class profileController : Controller{
        public ActionResult client(){
            Client clt = new Client{
                Client_Name = "Usman Ali Ahmed",
                Client_Email = "usmanamjad87@gmail.com",
                Client_Country = "Pakistan",
                Client_City = "Lahore",
                Client_Number = "+923314859236",
                Client_Gender = "Male",
            };
            return View(clt);
        }

        public ActionResult attorney(){
            Attorney atr = new Attorney{
                Attorney_Name = "Mohammad Kamran Ali",
                Attorney_Email = "kamran_ali84@gmail.com",
                Attorney_Country = "Pakistan",
                Attorney_City = "Islamabad",
                Attorney_Number = "+923314859236",
                Attorney_Gender = "Male",
                Attorney_Role = "Criminal Attorney",
                Attorney_DOB = "28 March 1978",
                Attorney_Certification = "Advanced Legal Research",
                Attorney_Firm = "Pearson Hardman, Cambridge, Massachusetts",
                Attorney_Education = "Harvard University, Cambridge, Massachusetts",
                Attorney_Experience = "12",
                Attorney_Cases = "15",
                Attorney_Languages = "English, Spanish, French"
            };
            return View(atr);
        }
    }
}