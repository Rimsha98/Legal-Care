using SeedaniLegalCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Text.RegularExpressions;

namespace SeedaniLegalCare.Controllers{
    public class articlesController : Controller{


        static string input = "<h2 class=\"mb-3\" style=\"font-family: Poppins, Arial, sans-serif; line-height: 1.5; color: rgba(0, 0, 0, 0.8);\">It is a long established fact a reader be distracted</h2><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\"><i><u>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis, eius mollitia suscipit, quisquam doloremque distinctio perferendis et doloribus unde architecto optio laboriosam porro adipisci sapiente officiis nemo accusamus ad praesentium? Esse minima nisi et. Dolore perferendis, enim praesentium omnis, iste doloremque quia officia optio deserunt molestiae voluptates soluta architecto tempora.</u></i></p><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\">Molestiae cupiditate inventore animi, maxime sapiente optio, illo est nemo veritatis repellat sunt doloribus nesciunt! Minima laborum magni reiciendis qui voluptate quisquam voluptatem soluta illo eum ullam incidunt rem assumenda eveniet eaque sequi deleniti tenetur dolore amet fugit perspiciatis ipsa, odit. Nesciunt dolor minima esse vero ut ea, repudiandae suscipit!</p><h2 class=\"mb-3 mt-5\" style=\"font-family: Poppins, Arial, sans-serif; line-height: 1.5; color: rgba(0, 0, 0, 0.8);\">#2. Creative WordPress Themes</h2><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\"><span style=\"font-weight: bolder;\">Temporibus ad error suscipit exercitationem hic molestiae totam obcaecati rerum, eius aut, in. Exercitationem atque quidem tempora maiores ex architecto voluptatum aut officia doloremque. Error dolore voluptas, omnis molestias odio dignissimos culpa ex earum nisi consequatur quos odit quasi repellat qui officiis reiciendis incidunt hic non? Debitis commodi aut, adipisci</span>.</p>";
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

        


        List<Article> articlelist = new List<Article> {

        new Article
        {
            ID=1,
            Approved="0",
            Author="Rimsha",
            Deleted="0",
            Title="Article related to Legal Care",
            Content=input,
            Date="20/1/2008",
            PostedBy="Attorney",
            Poster_Id=1
        },new Article
        {
            ID=2,
            Approved="0",
            Author="Asma",
            Deleted="0",
            Title="Article related to Health Care",
            Content=input,
            Date="20/1/2008",PostedBy="admin",
            Poster_Id=1
        },new Article
        {
            ID=3,
            Approved="0",
            Author="Fizza",
            Deleted="0",
            Title="Article related to Education",
            Content=input,
            Date="20/1/2008",
            PostedBy="attorney",
            Poster_Id=2
        },
        new Article
        {
            ID=4,
            Approved="1",
            Author="Rimsha",
            Deleted="0",
            Title="Article related to Legal Care",
            Content=input,
            Date="20/1/2008",
            PostedBy="attorney",
            Poster_Id=3
        },new Article
        {
            ID=5,
            Approved="1",
            Author="Asma",
            Deleted="0",
            Title="Article related to Health Care",
            Content=input,
            Date="20/1/2008",
            PostedBy="attorney",
            Poster_Id=4
        },new Article
        {
            ID=6,
            Approved="1",
            Author="Fizza",
            Deleted="0",
            Title="Article related to Education",
            Content=input,
            Date="20/1/2008",
            PostedBy="attorney",
            Poster_Id=5
        },
        new Article
        {
            ID=7,
            Approved="1",
            Author="Rimsha",
            Deleted="0",
            Title="Article related to Legal Care",
            Content=input,
            Date="20/1/2008",
            PostedBy="attorney",
            Poster_Id=6
        },new Article
        {
            ID=8,
            Approved="1",
            Author="Asma",
            Deleted="0",
            Title="Article related to Health Care",
            Content=input,
            Date="20/1/2008",
            PostedBy="attorney",
            Poster_Id=1
        },new Article
        {
            ID=9,
            Approved="1",
            Author="Fizza",
            Deleted="0",
            Title="Article related to Education",
            Content=input,
            Date="20/1/2008",
            PostedBy="attorney",
            Poster_Id=8
        },
        new Article
        {
            ID=10,
            Approved="1",
            Author="Rimsha",
            Deleted="0",
            Title="Article related to Legal Care",
            Content=input,
            Date="20/1/2008",
            PostedBy="attorney",
            Poster_Id=1
        },new Article
        {
            ID=11,
            Approved="1",
            Author="Asma",
            Deleted="0",
            Title="Article related to Health Care",
            Content=input,
            Date="20/1/2008",
            PostedBy="attorney",
            Poster_Id=1
        },new Article
        {
            ID=12,
            Approved="0",
            Author="Fizza",
            Deleted="0",
            Title="Article related to Education",
            Content=input,
            Date="20/1/2008",
            PostedBy="attorney",
            Poster_Id=1
        },
        };
        /* Users View */
        public ActionResult article(int Id){
            ViewBag.LinkText = "articles";
            Article articleview = articlelist.FirstOrDefault(x => x.ID == Id);
            return View(articleview);

        }

        [HttpGet]
        public ActionResult my_articles(string search,int? page)
        {
          
            List<Article> dummyarticllist = new List<Article>();
            dummyarticllist = articlelist;
            foreach (var item in dummyarticllist)
            {
                item.Content = StripHTML(input);

            }
            //Get Data w.r.t current user Id
            Login user = userlist.Find(x => x.user_Id == 1);
            int userID = Int32.Parse(user.Account_Id);
            if (!string.IsNullOrEmpty(search))
            {
                return View(articlelist.Where(x =>
                               x.Date.ToUpper().Contains(search.ToUpper()) ||
                               x.Title.ToUpper().Contains(search.ToUpper()) ||
                               x.Content.ToUpper().Contains(search.ToUpper())
                           ).ToPagedList(page ?? 1, 10));
            }
            else if (user.Account_type == "attorney")
            {
                return View(dummyarticllist.FindAll(x => x.Poster_Id == userID && x.PostedBy == user.Account_type).ToPagedList(page ?? 1, 10));
            }
            else
            {
                return View(dummyarticllist.ToPagedList(page ?? 1, 10));
            }
        }
        private List<Article> GetArticleList()
        {
            List<Article> articles = new List<Article>();
            for (int i = 0; i < 8; i++)
            {
                Article art = new Article();
                art.Title = "Corona virus spreads rapidly in Pakistan. What is the cause?";
                art.Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries";
                art.Date = "09th April 2020";
                articles.Add(art);

            }

            return articles;
        }

        public ActionResult list(string search, int? page)
        {
            ViewBag.LinkText = "articles";
            List<Article> dummyarticllist = new List<Article>();
            dummyarticllist = articlelist;
            foreach (var item in dummyarticllist)
            {
                item.Content = StripHTML(input);

            }
            if (!string.IsNullOrEmpty(search))
            {
                return View(articlelist.Where(x =>
                               x.Date.ToUpper().Contains(search.ToUpper()) ||
                               x.Title.ToUpper().Contains(search.ToUpper()) ||
                               x.Content.ToUpper().Contains(search.ToUpper())
                           ).ToPagedList(page ?? 1, 10));
            }
            else
            {
                return View(dummyarticllist.FindAll(x => x.Deleted == "0" && x.Approved == "1").ToPagedList(page ?? 1, 10));
            }
        }

    
        public ActionResult compose_article(){
            return View();
        }

        /* Admin View */
        public ActionResult edit_article(){
            ViewBag.LinkText = "articles";
            return View();
        }


        [HttpPost]
        public string delete_article(int EmployeeId)
        {
            string result;
            Article at = articlelist.Where(x => x.ID == EmployeeId).SingleOrDefault();

            if (at != null)
            {
                at.Deleted = "1";


                result = "1";
            }
            else
            {
                result = "0";
            }

            return result;
        }



        public ActionResult all_articles(string search,int? page,string pending){
            ViewBag.LinkText = "articles";
            List<Article> dummyarticllist = new List<Article>();
            dummyarticllist = articlelist;
            foreach (var item in dummyarticllist)
            {
                item.Content = StripHTML(input);

            }
            if (!string.IsNullOrEmpty(search))
            {
                return View(dummyarticllist.Where(x =>
                               x.Date.ToUpper().Contains(search.ToUpper()) ||
                               x.Title.ToUpper().Contains(search.ToUpper()) ||
                               x.Content.ToUpper().Contains(search.ToUpper())
                           ).ToPagedList(page ?? 1, 10));
            }
            else if (!string.IsNullOrEmpty(pending))
            {
                return View(dummyarticllist.FindAll(x => x.Deleted == "0" && x.Approved == "0").ToPagedList(page ?? 1, 10));

            }
            else
            {
                return View(dummyarticllist.FindAll(x => x.Deleted == "0"&&x.Approved=="1").ToPagedList(page ?? 1, 10));
            }
           
        }

        public ActionResult view_article(int Id){
            ViewBag.LinkText = "articles";
              Article articleview = articlelist.FirstOrDefault(x => x.ID == Id);
               return View(articleview);
        }

        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }


    }
}