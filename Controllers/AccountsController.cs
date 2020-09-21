using SeedaniLegalCare.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SeedaniLegalCare.Controllers{
    public class accountsController : Controller{

        List<Client> clientlist = new List<Client>
        {
            new Client
            {
            Client_ID=1,
            Client_Name="Rimsha Ishtiaq",
            Client_Country="Pakistan",
            Client_City="Karachi",
            Client_Email="Rimsha@gmail.com",
            Client_Gender="female",
            Client_Number="335765546576",
            Client_Password="123456",
            Approved="0",
            Block="1",
            Deleted="0"
        
            },
             new Client
            {
            Client_ID=2,
            Client_Name="Asma Riaz",
            Client_Country="Pakistan",
            Client_City="Karachi",
            Client_Email="Asma@gmail.com",
            Client_Gender="male",
            Client_Number="335765546576",
             Client_Password="567890",
            Approved="0",
            Block="0",
            Deleted="0"

            }
        };
        List<Login> userlist = new List<Login>
        {
            new Login
            {
                user_Id=1,
                Email="dev.rimshaishtiaq@gmail.com",
                Password="1224234",
                Account_Id="1",
                Account_type="attorney"
            },
            new Login
            {
                user_Id=2,
                Email="asmariaz@gmail.com",
                Password="1234567",
                Account_Id="1",
                Account_type="client"
            },
        };

        List<Attorney> attorney = new List<Attorney>
            {
                 new Attorney
                {

                    Approved="0",
                    Attorney_Cases="1",
                    Attorney_Certification="Abc",
                    Attorney_City="Karachi",
                    Attorney_Country="Pakistan",
                    Attorney_DOB="12/3/1996",
                    Attorney_Education="Graduate",
                    Attorney_Email="Rimsha@gmail.com",
                    Attorney_Experience="2",
                    Attorney_Firm="Abc",
                    Attorney_Gender="female",
                    Attorney_ID=1,
                   Attorney_Languages="English",
                   Attorney_Name="Rimsha",
                   Attorney_Number="+9222234235",
                   Attorney_Password="1224234",
                   Attorney_Role="Law Attroney",
                   Block="1"

                },
                new Attorney
                {
                    Approved="0",
                    Attorney_Cases="1",
                    Attorney_Certification="Abc",
                    Attorney_City="Wuhan",
                    Attorney_Country="China",
                    Attorney_DOB="12/3/1996",
                    Attorney_Education="Graduate",
                    Attorney_Email="Asma@gmail.com",
                    Attorney_Experience="2",
                    Attorney_Firm="Abc",
                    Attorney_Gender="male",
                    Attorney_ID=2,
                    Attorney_Languages="Chinese",
                    Attorney_Name="Asma",
                    Attorney_Number="+9222234235",
                    Attorney_Password="1224234",
                    Attorney_Role="Criminal Attroney",
                    Block="0"
                },


            };


        



        /* Login */
        public ActionResult login(){
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login user)
        {
            //if (btn != null)
            //{
            //    if (btn =="send"&& forgotemail != ""&&IsValidEmail(forgotemail))
            //    {
            //        //Check email in db
            //        //Contain in userlist work later

            //            Session["popup"] = "1";
            //            Session["code"] = getCode();
            //            sendEmail(forgotemail);

            //    }
            //    else if (btn.Equals("confirm"))
            //    {
            //        if (Session["code"].ToString() == code)
            //        {
            //            Session["popup"] = "2";
            //        }

            //    }
            //    else if (btn.Equals("save"))
            //    {
            //        //Save in DB
            //    }
            //}
            user = userlist.Find(x => x.user_Id == 1);
           
            if (user.Email == "client@gmail.com" && user.Password == "123")
            {
                user.Account_type = "client";
                Session["AccountType"] = "client";
                return RedirectToAction("index", "Home");
            }
            else if (user.Email == "attorney@gmail.com" && user.Email == "123")
            {
                user.Account_type = "attorney";
                Session["AccountType"] = "attorney";
                return RedirectToAction("index", "Home");
            }
            else if (user.Email == "admin@legalcare.com" && user.Email == "123")
            {
                user.Account_type = "admin";
                Session["AccountType"] = "admin";
                return RedirectToAction("approve_clients", "accounts");
            }
            else
            {
                Session["AccountType"] = null;
            }
            Session["User"] = user;
            return View(user);
        }

        public bool verify_email_from_db(string email)
        {
            Login user = userlist.FirstOrDefault(x => x.Email == email);
            
            
            if (user!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string verifyfp_email(string email)
        {
            //Session["AccountType"] = null;
            //return RedirectToAction("index", "Home");
           if(IsValidEmail(email)&&verify_email_from_db(email))
            {
                Session["code"] = getCode();
                sendEmail(email);
                return "1";
            }
            return "0";
        }
        
        public string verifyfp_code(string code)
        {
            //Session["AccountType"] = null;
            //return RedirectToAction("index", "Home");
           if(Session["code"].ToString() == code)
            {
               
                return "1";
            }
            return "0";
        } 
        
        public string savefp_password(string password,string emailId)
        {
            Login user = userlist.FirstOrDefault(x => x.Email == emailId);
            if (password.Length>6 && user.Email == emailId)
            {   int id = Int32.Parse(user.Account_Id);
                //update password in tables
                user.Password = password;
                if(user.Account_type == "attorney")
                {
                    Attorney at = attorney.FirstOrDefault(x =>x.Attorney_ID ==id );
                    at.Attorney_Password = password;
                }
                else if(user.Account_type == "client")
                {
                    Client cl = clientlist.FirstOrDefault(x =>x.Client_ID ==id );
                    cl.Client_Password = password;
                }
                return "1";
            }
            else
            {
                return "0";
            }
     
            
        }
        
        public ActionResult Logout()
        {
            Session["AccountType"] = null;
            return RedirectToAction("index", "Home");
        }
        /* User Registeration */


        public ActionResult client_registration()
        {
            //List<string> country = new List<string>();
            //country.Add("pakistan");
            //country.Add("America");
            //country.Add("China"); 
            //List<string> code = new List<string>();
            //country.Add("+92");
            //country.Add("+12");
            //country.Add("+33");
            //SelectList list = new SelectList(country, code);
            Session["btn"] = null;
            Session["loadpage"] = null;

            List<SelectListItem> Country = new List<SelectListItem>() {
        new SelectListItem {
            Text = "Pakistan", Value = "+92"
        },
        new SelectListItem {
            Text = "America", Value = "+00"
        },
        new SelectListItem {
            Text = "China", Value = "+77"
        },

      };
            ViewBag.Country = Country;



            return View();
        }

        [HttpPost]
        public ActionResult client_registration(Client Client,HttpPostedFileBase imgInp, string tabButton, string ContryName,string codeinput)
        {
            if(ContryName=="")
            {
                ContryName = "Pakistan";
                Client.Client_Country = "+92";

            }
            Client.Client_Number = Client.Client_Country + Client.Client_Number;
            Client.Client_Country = ContryName;
            Client.Approved = "0";
            Client.Block = "0";

            List<SelectListItem> Country = new List<SelectListItem>() {
        new SelectListItem {
            Text = "Pakistan", Value = "+92"
        },
        new SelectListItem {
            Text = "America", Value = "+00"
        },
        new SelectListItem {
            Text = "China", Value = "+77"
        },

      };
            ViewBag.Country = Country;



            Client dummyclient = new Client();
            //dummyclient = clientlist.Find(x => x.Client_Email == Client.Client_Email);
            dummyclient.Client_Email = "rimsha@g";

           
            //Next Step Button
            if (tabButton != null) {
               
            if (tabButton.Equals("next"))
            {
               if( Check_Validation(Client))
                {
                        if (dummyclient!=null && dummyclient.Client_Email == Client.Client_Email)
                        {
                            ModelState.AddModelError("Client_Email", "already registered email");
                        }
                        else
                        {
                            
                               Session["btn"] = "1";
                        }
                }
                //else
                //{
                //    Session["btn"] = "0";
                //}
            }
            else if (tabButton.Equals("finish"))
            {
             Session["code"] = getCode();
             sendEmail(Client.Client_Email);
            }
            else if (tabButton.Equals("verify"))
             {
             if (Session["code"].ToString() == codeinput)
              {
                 if (ModelState.IsValid)
                  {
                            if (imgInp != null)
                            {
                                Client.Client_Image = Client.Client_Email + Path.GetExtension(imgInp.FileName);
                                imgInp.SaveAs(Server.MapPath("//Content//UserImages//") + Client.Client_Image);
                            }

                            //clientlist.Add(Client);
                           
                            return RedirectToAction("login", "accounts");
                          
                   }
              }
              else { 
                    Session["loadpage"] = "1";
                    ViewBag.InvalidCode = "Invalid Code";
                 }
             }
            }
   


            return View(Client);
        }


        public ActionResult attorney_registration()
        {
            List<SelectListItem> Country = new List<SelectListItem>() {
        new SelectListItem {
            Text = "Pakistan", Value = "+92"
        },
        new SelectListItem {
            Text = "America", Value = "+00"
        },
        new SelectListItem {
            Text = "China", Value = "+77"
        },

      };
            ViewBag.Country = Country;

            int a = 0;
            return View();
        }

        [HttpPost]
        public ActionResult attorney_registration(Attorney attorney, HttpPostedFileBase imgInp, string next,string ContryName, string codeinput,string role)
        {
            if (ContryName == "")
            {
                ContryName = "Pakistan";
                attorney.Attorney_Country = "+92";

            }
            attorney.Attorney_Number = attorney.Attorney_Country + attorney.Attorney_Number;
            attorney.Attorney_Country = ContryName;
            attorney.Approved = "0";
            attorney.Block = "0";
            attorney.Attorney_Role = role;

            List<SelectListItem> Country = new List<SelectListItem>() {
        new SelectListItem {
            Text = "Pakistan", Value = "+92"
        },
        new SelectListItem {
            Text = "America", Value = "+00"
        },
        new SelectListItem {
            Text = "China", Value = "+77"
        },

      };
            ViewBag.Country = Country;
            //Next Step Button
            if (next != null)
            {
                if (next.Equals("step1next"))
                {
                    if (Attorney_Step1_Validator(attorney))
                    {
                        Session["activetab"] = "1";
                    }
                    //else
                    //{
                    //    Session["activetab"] = "0";
                    //}


                }else if(next.Equals("step2next"))
                {
                    
                    
                        if (ModelState.IsValid)
                        {
                        if (role.Equals("0"))
                        {
                            ModelState.AddModelError("Attorney_Role", "please select your role");
                        }
                        else
                        {
                            ModelState.AddModelError("Attorney_Role","");
                            Session["activetab"] = "2";
                        }
                        }
                    
                    
                }
                else if (next.Equals("finish"))
                {
                    Session["code"] = getCode();
                    sendEmail(attorney.Attorney_Email);
                  
                }
                else if (next.Equals("verify"))
                {
                    if (Session["code"].ToString() == codeinput)
                    {
                        if (ModelState.IsValid)
                        {
                            if (imgInp != null)
                            {
                                attorney.Attorney_Image = attorney.Attorney_Email + Path.GetExtension(imgInp.FileName);
                                imgInp.SaveAs(Server.MapPath("//Content//UserImages//") + attorney.Attorney_Image);
                            }

                            //clientlist.Add(Client);

                            //Session["load"] = "0";
                            return RedirectToAction("login", "accounts");
                        }
                    }
                    else {
                        Session["load"] = "1";
                        ViewBag.InvalidCode = "Invalid Code"; 
                    }
                }
            }
        
            return View(attorney);
        }

        //public JsonResult Check_Validation()
        //{
        //    string check = "true";
        //    if (!ModelState.IsValidField("Client_Name"))
        //    {
        //        check = "false";
        //    }
        //    else if (!ModelState.IsValidField("Client_Email"))
        //    {
        //        check = "false";
        //    }
        //    else if (!ModelState.IsValidField("Client_Password"))
        //    {
        //        check = "false";
        //    }
        //    else if (!ModelState.IsValidField("Client_ConfirmPassword"))
        //    {
        //        check = "false";
        //    }
        //    else if (!ModelState.IsValidField("Client_City"))
        //    {
        //        check = "false";
        //    }
        //    else if (!ModelState.IsValidField("Client_Number"))
        //    {
        //        check = "false";
        //    }
        //    else
        //    {
        //        check = "true";
        //    }
        //    string message = "Welcome";
        //    return new JsonResult { Data = check, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}
        public bool Check_Validation(Client Client)
        {
            bool check = true;
            if (!ModelState.IsValidField("Client_Name"))
            {
                check = false;
            }
            else if (!ModelState.IsValidField("Client_Email"))
            {
                check = false;
            }
            else if (!ModelState.IsValidField("Client_Password"))
            {
                check = false;
            }
            else if (!ModelState.IsValidField("Client_ConfirmPassword"))
            {
                check = false;
            }
            else if (!ModelState.IsValidField("Client_City"))
            {
                check = false;
            }
            else if (!ModelState.IsValidField("Client_Number"))
            {
                check = false;
            }
            else
            {
                check = true;
            }
            return check;

        }


        public bool Attorney_Step1_Validator(Attorney attorney)
        {
            bool check = true;
            if (!ModelState.IsValidField("Attorney_Name"))
            {
                check = false;
            }
            else if (!ModelState.IsValidField("Attorney_Email"))
            {
                check = false;
            }
            else if (!ModelState.IsValidField("Attorney_Password"))
            {
                check = false;
            }
            else if (!ModelState.IsValidField("Attorney_ConfirmPassword"))
            {
                check = false;
            }
            else if (!ModelState.IsValidField("Attorney_City"))
            {
                check = false;
            }
            else if (!ModelState.IsValidField("Attorney_Number"))
            {
                check = false;
            }
            else
            {
                check = true;
            }
            return check;

        }



        //[HttpPost]
        //public ActionResult client_registration(Client client)
        //{
        //    return View();
        //}

      

        /* User Account Settings */
        public ActionResult settings(){
            return View();
        }

        /* Register User Accounts */
        public ActionResult approve_attorneys(){
            ViewBag.LinkText = "approve_users";
            return View(attorney);
        }
        public JsonResult save_attorney(int EmployeeId)
        {
            bool result = false;
            Attorney at = attorney.Where(x => x.Attorney_ID == EmployeeId).SingleOrDefault();
            if (at != null)
            {
                at.Deleted = "0";
                at.Approved = "1";

                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult approve_clients(){
            ViewBag.LinkText = "approve_users";
            return View(clientlist);
        }

        /* Manage Users */
        public ActionResult client_accounts(){
            ViewBag.LinkText = "manage_users";
            return View(clientlist);
        }
        public JsonResult delete_client(int EmployeeId)
        {
            bool result = false;
            Client cl = clientlist.Where(x => x.Client_ID == EmployeeId).SingleOrDefault();
            if (cl != null)
            {
                cl.Deleted = "1";
                cl.Approved = "0";

                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ban_client(int EmployeeId)
        {
            bool result = false;
            Client cl = clientlist.Where(x => x.Client_ID == EmployeeId).SingleOrDefault();
            if (cl != null)
            {
                cl.Block = "0";

                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult save_client(int EmployeeId)
        {
            bool result = false;
            Client cl = clientlist.Where(x => x.Client_ID == EmployeeId).SingleOrDefault();
            if (cl != null)
            {
                cl.Deleted = "0";
                cl.Approved = "1";

                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /* Attorney Accounts */
        public ActionResult attorney_accounts(){
            ViewBag.LinkText = "manage_users";
            return View(attorney);
            
        }
       
        public ActionResult attorney_details(int Id)
        {
            Attorney frnds = new Attorney();

            frnds = attorney.Find(x => x.Attorney_ID == Id);
            return PartialView(frnds);
        }

        public JsonResult delete_attorney(int EmployeeId)
        {
            bool result = false;
            Attorney at = attorney.Where(x => x.Attorney_ID == EmployeeId).SingleOrDefault();
            if (at != null)
            {
                at.Deleted = "1";
                at.Approved = "0";
                
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ban_attorney(int EmployeeId)
        {
            bool result = false;
            Attorney at = attorney.Where(x => x.Attorney_ID == EmployeeId).SingleOrDefault();
            if (at != null)
            {
                at.Block = "0";
                
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /* Reported Accounts */
        public ActionResult reported_accounts(){
            ViewBag.LinkText = "reported_accounts";
            return View();
        }


        
        //Functions
        private void sendEmail(string email)
        {
            //ViewState["fpcode"] = (r.Next(1000, 9999).ToString("D4"));
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new System.Net.NetworkCredential("emailid", "password");
           
            smtp.EnableSsl = true;

            MailMessage msg = new MailMessage();
            msg.Subject = "Pakistan's Legal Care | Account Activation ";
            msg.Body = "Dear Your account activation code is Here!\nKindly copy the code and paste in required field\n\n\t\t\t\t" + Session["code"] + "\n\nIf you face any problems during password recovery, kindly contact us:\n4bitdevelopers@gmail.com";
            string to = email;
            msg.To.Add(to);

            string from = "Pakistan's Legal Care  <Reference email>";
            msg.From = new MailAddress(from);
            try
            {
                smtp.Send(msg);
            }
            catch
            {
                //Internet Error
            }
           
            
        }

        public string getCode()
        {
            Random r = new Random();
            string code = "";
            for (int i = 0; i < 4; i++)
            {
                int a = r.Next(0, 9);
                code = code + a.ToString();
            }
            return code;
        }

        public bool IsValidEmail(string email) {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /* Account Settings Attorney*/
        public ActionResult settings_attorney(string role)
        {
            List<SelectListItem> Country = new List<SelectListItem>() {
        new SelectListItem {
            Text = "Pakistan", Value = "+92"
        },
        new SelectListItem {
            Text = "America", Value = "+00"
        },
        new SelectListItem {
            Text = "China", Value = "+77"
        },

      }; ViewBag.Country = Country;
         
            role = "0";
            if (role.Equals("0"))
            {
                ModelState.AddModelError("Attorney_Role", "please select your role");
            }
            else
            {
                ModelState.AddModelError("Attorney_Role"," ");

            }

            Login user = (Login)Session["User"];
            int accountid = 1;
            Attorney at = attorney.Find(x => x.Attorney_ID == accountid);
            string number = at.Attorney_Number.Substring(3);
            at.Attorney_Number = number;
            at.Attorney_Password = "";

            ViewBag.LinkText = "reported_accounts";
            return View(at);
        } 
        
        [HttpPost]
        public ActionResult settings_attorney(Attorney at,string role,string ContryName, HttpPostedFileBase imgInp)
        {
            ViewBag.LinkText = "account_Settings";
            List<SelectListItem> Country = new List<SelectListItem>() {
        new SelectListItem {
            Text = "Pakistan", Value = "+92"
        },
        new SelectListItem {
            Text = "America", Value = "+00"
        },
        new SelectListItem {
            Text = "China", Value = "+77"
        },

      }; 
            ViewBag.Country = Country;

            Login user = (Login)Session["User"];
            int accountid = 1;
            Attorney update_attorney = attorney.Find(x => x.Attorney_ID == accountid);
            if (ContryName == "")
            {
                ContryName = "Pakistan";
                update_attorney.Attorney_Country = "+92";

            }
            


            update_attorney.Attorney_Number = update_attorney.Attorney_Country + at.Attorney_Number;
            update_attorney.Attorney_Country = ContryName;
            update_attorney.Attorney_Role = role;
            update_attorney.Attorney_Cases = at.Attorney_Cases;
            update_attorney.Attorney_Certification = at.Attorney_Certification;
            update_attorney.Attorney_City = at.Attorney_City;
            update_attorney.Attorney_DOB = at.Attorney_DOB;
            update_attorney.Attorney_Education = at.Attorney_Education;
            update_attorney.Attorney_Experience = at.Attorney_Experience;
            update_attorney.Attorney_Firm = at.Attorney_Firm;
            update_attorney.Attorney_Image = at.Attorney_Image;
            update_attorney.Attorney_Name = at.Attorney_Name;
            update_attorney.Attorney_Languages = at.Attorney_Languages;


            string number = update_attorney.Attorney_Number.Substring(3);
            at.Attorney_Number = number;
            at.Attorney_Password = "";
            at.Attorney_Email = update_attorney.Attorney_Email;
            
            if (Accounts_Setting_Verification_Attorney(at))
            {
                ModelState.Clear();
                if (role.Equals("0"))
                {
                    ModelState.AddModelError("Attorney_Role", "please select your role");
                }
                else
                {
                    ModelState.AddModelError("Attorney_Role", " ");
                    if (imgInp != null)
                    {
                        update_attorney.Attorney_Image = update_attorney.Attorney_Email + Path.GetExtension(imgInp.FileName);
                        imgInp.SaveAs(Server.MapPath("//Content//UserImages//") + update_attorney.Attorney_Image);
                    }
                    TempData["save"] = "<script>alert('update successfully ');</script>";
                    
                    //Update data here
                    return View(at);
                }
                

               
               
            }

            return View(at);
        }


        public string match_password(string password)
        {
            bool check = false;
             Login user = (Login)Session["User"];
            int accountid = 1;
            string Accounttype = "client";
            if (Accounttype == "attorney")
            {
                Attorney at = attorney.FirstOrDefault(x => x.Attorney_ID == accountid);
                if (at.Attorney_Password == password)
                {
                    check = true;
                  
                }
                
            }
            else if (Accounttype == "client")
            {
                Client cl = clientlist.FirstOrDefault(x => x.Client_ID == accountid);
                if (cl.Client_Password == password)
                {
                    
                    check = true;
                }

            }
            else
            {
                check = false;
            }

           
            if(check==true)
            {
                return "1";
            }
            else
            {
                return "0";
            }

        }

        public bool Accounts_Setting_Verification_Attorney(Attorney attorney)
        {
            bool check = true;
            if (!ModelState.IsValidField("Attorney_Name"))
            {
                check = false;
            }
            else if (!ModelState.IsValidField("Attorney_DOB"))
            {
                check = false;
            }
           
            else if (!ModelState.IsValidField("Attorney_City"))
            {
                check = false;
            }
            else if (!ModelState.IsValidField("Attorney_Number"))
            {
                check = false;
            } 
            else if (!ModelState.IsValidField("Attorney_Education"))
            {
                check = false;
            } else if (!ModelState.IsValidField("Attorney_Experience"))
            {
                check = false;
            }else if (!ModelState.IsValidField("Attorney_Cases"))
            {
                check = false;
            }else if (!ModelState.IsValidField("Attorney_Languages"))
            {
                check = false;
            }else if (!ModelState.IsValidField("Attorney_Firm"))
            {
                check = false;
            }else if (!ModelState.IsValidField("Attorney_Certification"))
            {
                check = false;
            }
            else
            {
                check = true;
            }
            return check;

        }
        public bool Accounts_Setting_Verification_Client(Client client)
        {
            bool check = true;
            if (!ModelState.IsValidField("Client_Name"))
            {
                check = false;
            }
           
            else if (!ModelState.IsValidField("Client_City"))
            {
                check = false;
            }
            else if (!ModelState.IsValidField("Client_Number"))
            {
                check = false;
            } 
           
            else
            {
                check = true;
            }
            return check;

        }

        /*Account Setting Client */
        public ActionResult settings_client()
        {
            List<SelectListItem> Country = new List<SelectListItem>() {
        new SelectListItem {
            Text = "Pakistan", Value = "+92"
        },
        new SelectListItem {
            Text = "America", Value = "+00"
        },
        new SelectListItem {
            Text = "China", Value = "+77"
        },

      }; ViewBag.Country = Country;

            

            Login user = (Login)Session["User"];
            int accountid = 1;
            Client cl = clientlist.Find(x => x.Client_ID == accountid);
            string number = cl.Client_Number.Substring(3);
            cl.Client_Number = number;
            cl.Client_Password = "";

            ViewBag.LinkText = "reported_accounts";
            return View(cl);
        }

        [HttpPost]
        public ActionResult settings_client(Client at, string ContryName, HttpPostedFileBase imgInp)
        {
            ViewBag.LinkText = "account_Settings";
            List<SelectListItem> Country = new List<SelectListItem>() {
        new SelectListItem {
            Text = "Pakistan", Value = "+92"
        },
        new SelectListItem {
            Text = "America", Value = "+00"
        },
        new SelectListItem {
            Text = "China", Value = "+77"
        },

      };
            ViewBag.Country = Country;

            Login user = (Login)Session["User"];
            int accountid = 1;
            Client update_client = clientlist.Find(x => x.Client_ID == accountid);
            if (ContryName == "")
            {
                ContryName = "Pakistan";
                update_client.Client_Country = "+92";

            }



            update_client.Client_Number = update_client.Client_Country + at.Client_Number;
            update_client.Client_Country = ContryName;
            update_client.Client_City = at.Client_City;
            update_client.Client_Name = at.Client_Name;
           
            string number = update_client.Client_Number.Substring(3);
            at.Client_Number = number;
            at.Client_Password = "";
            at.Client_Email = update_client.Client_Email;

            if (Accounts_Setting_Verification_Client(at))
            {
                ModelState.Clear();
                
                   
                    if (imgInp != null)
                    { 
                    update_client.Client_Image = update_client.Client_Email + Path.GetExtension(imgInp.FileName);
                        imgInp.SaveAs(Server.MapPath("//Content//UserImages//") + update_client.Client_Image);
                    }
                    TempData["save"] = "<script>alert('update successfully ');</script>";

                    //Update data here
                    return View(at);
            
            }

            return View(at);
        }



    }




}
 
 