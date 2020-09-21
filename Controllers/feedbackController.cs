using PagedList;
using PagedList.Mvc;
using SeedaniLegalCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeedaniLegalCare.Controllers{
    public class feedbackController : Controller{
        int AttorneyID = 1;

        /* Load feedback list */
        private List<Feedback> LoadFeedback(){
            List<Feedback> fdback = new List<Feedback>();

            for (int i = 0; i < 25; i++){
                Feedback fb = new Feedback();
                fb.Client_Name = "Farhan Ahmed Siddiqui";
                fb.Client_Email = "farhan@hotmail.com";
                fb.Client_Feedback = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.";
                fb.Client_Rating = 3;
                fb.Date = "28 March 2019";
                fdback.Add(fb);
            }

            for (int j = 0; j < 13; j++){
                Feedback fb1 = new Feedback();
                fb1.Client_Name = "Ayesha Hassan";
                fb1.Client_Email = "ayeshahassan@hotmail.com";
                fb1.Client_Feedback = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.";
                fb1.Client_Rating = 1;
                fb1.Date = "02 February 2019";
                fdback.Add(fb1);
            }
            
            Calculate_Stats(fdback);
            return fdback;
        }

        /* return feedback list + search in list + pagination */
        public ActionResult list(string search, int? page){
            ViewBag.LinkText = "feedback";
            List<Feedback> temp = LoadFeedback();
            if (!string.IsNullOrEmpty(search)){
                ViewBag.ShowDetails = false;
                return View(temp.Where(x =>
                               x.Client_Name.ToUpper().Contains(search.ToUpper()) ||
                               x.Client_Feedback.ToUpper().Contains(search.ToUpper()) ||
                               x.Client_Email.ToUpper().Contains(search.ToUpper()) ||
                               x.Date.ToUpper().Contains(search.ToUpper())
                           ).ToPagedList(page ?? 1, 15));
            }
            else
            {
                ViewBag.ShowDetails = true;
                ViewData["count"] = 1;
                return View(LoadFeedback().ToPagedList(page ?? 1, 15));
            }
        }

        /* calculate percentages of total feedback */
        public void Calculate_Stats(List<Feedback> fdback){
            float[] values = new float[6];
            for (int i = 0; i < fdback.Count; i++){
                int value = fdback[i].Client_Rating;
                if (value.Equals(1))
                    values[0] = values[0] + 1;
                else if (value.Equals(2))
                    values[1] = values[1] + 1;
                else if (value.Equals(3))
                    values[2] = values[2] + 1;
                else if (value.Equals(4))
                    values[3] = values[3] + 1;
                else if (value.Equals(5))
                    values[4] = values[4] + 1;
            }
            values[5] = fdback.Count;

            for (int i=0; i<5; i++){
                float a = values[i] / values[5];
                values[i] = (float)Math.Round(a, 2);
            }

            ViewData["percentages"] = values;

        }

        /* Load Networks list */
        private List<Network> LoadNetworks(){
            List<Network> connections = new List<Network>();
            for(int i = 0; i < 6; i++){
                Network ntwork = new Network();
                ntwork.Client_ID = 1;
                ntwork.Attorney_ID = i+20;
                ntwork.Attorney_Name = "Muhammad Kamran Ali";
                ntwork.Attorney_Role = "Criminal Attorney" + i.ToString() + "";
                ntwork.Connection_Date = "29th March 2019";
                connections.Add(ntwork);

                Network ntwork1 = new Network();
                ntwork1.Client_ID = 2;
                ntwork1.Attorney_ID = i + 20;
                ntwork1.Attorney_Name = "Syeda Iqra Waseem";
                ntwork1.Attorney_Role = "Law Attorney" + i.ToString() + "";
                ntwork1.Connection_Date = "01 January 2018";
                connections.Add(ntwork1);
            }
            return connections; 
        }

        /* search + pagination attorneys */
        [HttpGet]
        public ActionResult attorneys(string search, int? page)
        {
            ViewBag.LinkText = "feedback";
            List<Network> temp = LoadNetworks();
            if (!string.IsNullOrEmpty(search))
            {
                return View(temp.Where(x =>
                               x.Attorney_Name.ToUpper().Contains(search.ToUpper()) ||
                               x.Attorney_Role.ToUpper().Contains(search.ToUpper()) ||
                               x.Connection_Date.ToUpper().Contains(search.ToUpper())
                           ).ToPagedList(page ?? 1, 3));
            }
            else
            {
                return View(LoadNetworks().ToPagedList(page ?? 1, 3));
            }
        }
        public void SendEmails(string ID, string Feedback, string RatingValue)
        {
            string Attorney_ID = ID;
            string fb = Feedback;
            string Rating = RatingValue;
            string Date = DateTime.Now.ToString("M/d/yyyy");
        }

        /* admin */
        [HttpPost]
        public ActionResult all_attorneys(string role, int? page)
        {
            ViewBag.LinkText = "feedback";
            List<Attorney> temp = LoadAttorneys();
            if (!string.IsNullOrEmpty(role))
            {
                return View(temp.Where(x =>
                               x.Attorney_Role.ToUpper().Contains(role.ToUpper())
                           ).ToPagedList(page ?? 1, 3));
            }
            else
            {
                return View(temp.ToPagedList(page ?? 1, 3));
            }
            
        }

        [HttpGet]
        public ActionResult all_attorneys(int? page)
        {
            ViewBag.LinkText = "feedback";
            List<Attorney> temp = LoadAttorneys();
            return View(temp.ToPagedList(page ?? 1, 3));
        }

        public ActionResult all()
        {
            ViewBag.LinkText = "feedback";
            Session["AttorneyID"] = 1;
            return RedirectToAction("all_feedback");
        }

        private List<Attorney> LoadAttorneys()
        {
            List<Attorney> attorney_list = new List<Attorney>();
            for (int i = 0; i < 3; i++)
            {
                Attorney atr = new Attorney();
                atr.Attorney_ID = i;
                atr.Attorney_Name = "Mohammad Kamran";
                atr.Attorney_Role = "Criminal Attorney";
                attorney_list.Add(atr);

                Attorney atr1 = new Attorney();
                atr1.Attorney_ID = i;
                atr1.Attorney_Name = "Syeda Iqra Waseem";
                atr1.Attorney_Role = "Law Attorney";
                attorney_list.Add(atr1);

                Attorney atr2 = new Attorney();
                atr2.Attorney_ID = i;
                atr2.Attorney_Name = "Fizza Fatima Naqvi";
                atr2.Attorney_Role = "Tax Attorney";
                attorney_list.Add(atr2);
            }
            return attorney_list;
        }

        public ActionResult all_feedback(string search, int? page)
        {
            ViewBag.LinkText = "feedback";
            string[] Attorney = {"Mohammad Kamran","Criminal Attorney"};
            ViewData["AttorneyDetail"] = Attorney;


            List<Feedback> temp = LoadFeedback();
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.ShowDetails = false;
                return View(temp.Where(x =>
                               x.Client_Name.ToUpper().Contains(search.ToUpper()) ||
                               x.Client_Feedback.ToUpper().Contains(search.ToUpper()) ||
                               x.Client_Email.ToUpper().Contains(search.ToUpper()) ||
                               x.Date.ToUpper().Contains(search.ToUpper())
                           ).ToPagedList(page ?? 1, 15));
            }
            else
            {
                ViewBag.ShowDetails = true;
                ViewData["count"] = 1;
                return View(temp.ToPagedList(page ?? 1, 15));
            }
        }
    }
}