using SeedaniLegalCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Net.Mail;

namespace SeedaniLegalCare.Controllers
{
    public class contactController : Controller
    {
        [HttpPost]
        public ActionResult message(string name, string email, string message, string subject)
        {
            Contact query = new Contact();
            query.Name = name;
            query.Subject = subject;
            query.Email = email;
            query.Message = message;

            ViewBag.LinkText = "contact";
            return View();
        }

        [HttpGet]
        public ActionResult message()
        {
            return View();
        }

        private List<Contact> GetMessages()
        {
            List<Contact> Queries = new List<Contact>();
            for(int i = 0; i < 10; i++)
            {
                Contact query = new Contact();
                query.ID = i;
                query.Name = "Asma Riaz";
                query.Email = "asmamalik@hotmail.com";
                query.Subject = "May I know your location?";
                query.Message = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
                query.Date = "27/03/2020";
                Queries.Add(query);
            }

            for (int i = 0; i < 4; i++)
            {
                Contact query = new Contact();
                query.ID = i;
                query.Name = "Fizza Fatima";
                query.Email = "fizza@hotmail.com";
                query.Subject = "May I know your location?";
                query.Message = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
                query.Date = "04/02/2017";
                Queries.Add(query);
            }
            return Queries; 
        }

        public ActionResult queries( string search, int? page)
        {
            ViewBag.LinkText = "contact";
            List<Contact> temp = GetMessages();
            if (!string.IsNullOrEmpty(search))
            {
                return View(temp.Where(x =>
                               x.Name.ToUpper().Contains(search.ToUpper()) ||
                               x.Email.ToUpper().Contains(search.ToUpper()) ||
                               x.Subject.ToUpper().Contains(search.ToUpper()) ||
                               x.Date.ToUpper().Contains(search.ToUpper())
                           ).ToPagedList(page ?? 1, 8));
            }
            else
            {
                return View(GetMessages().ToPagedList(page ?? 1, 8));
            }
        }

        private List<Contact> user()
        {
            List<Contact> contacts = new List<Contact>();
            Contact cnt = new Contact();
            cnt.Name = "Asma Riaz";
            cnt.Email = "asma@gmail.com";
            cnt.Date = "23/04/2020";
            cnt.Message = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis, eius mollitia suscipit, quisquam doloremque distinctio perferendis et doloribus unde architecto optio laboriosam porro adipisci sapiente officiis nemo accusamus ad praesentium? Esse minima nisi et. Dolore perferendis, enim praesentium omnis, iste doloremque quia officia optio deserunt molestiae voluptates soluta architecto tempora. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis, eius mollitia suscipit, quisquam doloremque distinctio perferendis et doloribus unde architecto optio laboriosam porro adipisci sapiente officiis nemo accusamus ad praesentium? Esse minima nisi et. Dolore perferendis, enim praesentium omnis, iste doloremque quia officia optio deserunt molestiae voluptates soluta architecto tempora. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis, eius mollitia suscipit, quisquam doloremque distinctio perferendis et doloribus unde architecto optio laboriosam porro adipisci sapiente officiis nemo accusamus ad praesentium? Esse minima nisi et. Dolore perferendis, enim praesentium omnis, iste doloremque quia officia optio deserunt molestiae voluptates soluta architecto tempora. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis, eius mollitia suscipit, quisquam doloremque distinctio perferendis et doloribus unde architecto optio laboriosam porro adipisci sapiente officiis nemo accusamus ad praesentium? Esse minima nisi et. Dolore perferendis, enim praesentium omnis, iste doloremque quia officia optio deserunt molestiae voluptates soluta architecto tempora. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis, eius mollitia suscipit, quisquam doloremque distinctio perferendis et doloribus unde architecto optio laboriosam porro adipisci sapiente officiis nemo accusamus ad praesentium? Esse minima nisi et. Dolore perferendis, enim praesentium omnis, iste doloremque quia officia optio deserunt molestiae voluptates soluta architecto tempora.";
            cnt.Subject = "This is my subject title where I defined my question";
            contacts.Add(cnt);
            return contacts;
        }

        public ActionResult query()
        {
            ViewBag.LinkText = "contact";
            return View(user());
        }

        public ActionResult query_response()
        {
            ViewBag.LinkText = "contact";
            ViewData["Emails"] = new string[] { "4bitdevelopers@gmail.com", "asmaryazmalik96@gmail.com" };
            return View();
        }

        [HttpPost]
        public ActionResult sendemail(string email, string subject, string message)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new System.Net.NetworkCredential("", "");

            smtp.EnableSsl = true;

            MailMessage msg = new MailMessage();
            msg.Subject = "Legalcare Query Response | " + subject;
            msg.Body = "Hello,\n\n" + message + "\n\nRegards.\nAsma Riaz\nLegalcare Administrator";
            string to = email;
            msg.To.Add(to);

            string from = "Legalcare <>";
            msg.From = new MailAddress(from);
            try
            {
                smtp.Send(msg);
            }
            catch
            {
                //Internet Error
            }
            return RedirectToAction("query_response");
        }

        
    }
}