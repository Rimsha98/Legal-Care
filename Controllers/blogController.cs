using SeedaniLegalCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace SeedaniLegalCare.Controllers{
    public class blogController : Controller {

        static string input = "<h2 class=\"mb-3\" style=\"font-family: Poppins, Arial, sans-serif; line-height: 1.5; color: rgba(0, 0, 0, 0.8);\">It is a long established fact a reader be distracted</h2><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\"><i><u>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis, eius mollitia suscipit, quisquam doloremque distinctio perferendis et doloribus unde architecto optio laboriosam porro adipisci sapiente officiis nemo accusamus ad praesentium? Esse minima nisi et. Dolore perferendis, enim praesentium omnis, iste doloremque quia officia optio deserunt molestiae voluptates soluta architecto tempora.</u></i></p><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\">Molestiae cupiditate inventore animi, maxime sapiente optio, illo est nemo veritatis repellat sunt doloribus nesciunt! Minima laborum magni reiciendis qui voluptate quisquam voluptatem soluta illo eum ullam incidunt rem assumenda eveniet eaque sequi deleniti tenetur dolore amet fugit perspiciatis ipsa, odit. Nesciunt dolor minima esse vero ut ea, repudiandae suscipit!</p><h2 class=\"mb-3 mt-5\" style=\"font-family: Poppins, Arial, sans-serif; line-height: 1.5; color: rgba(0, 0, 0, 0.8);\">#2. Creative WordPress Themes</h2><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\"><span style=\"font-weight: bolder;\">Temporibus ad error suscipit exercitationem hic molestiae totam obcaecati rerum, eius aut, in. Exercitationem atque quidem tempora maiores ex architecto voluptatum aut officia doloremque. Error dolore voluptas, omnis molestias odio dignissimos culpa ex earum nisi consequatur quos odit quasi repellat qui officiis reiciendis incidunt hic non? Debitis commodi aut, adipisci</span>.</p>";
      
        
        static List<comments> commentlist = new List<comments> {

        new comments
        {
            blog_Id=1,
            comment_Id=1,
            email="Rimsha@gmial.com",
            message="This comment is for blog 1",
            name="Rimsha",
            IsReply="0",
            comment_reply_Id=0,
            Date="20/1/2008"
        },
            new comments
        {
            blog_Id=1,
            comment_Id=2,
            email="Hamza@gmial.com",
            message="This comment is reply comment to this blog",
            name="Hamza",
            IsReply="1",
            comment_reply_Id=1,
            Date="20/1/2008"
        },
            new comments
        {
            blog_Id=1,
            comment_Id=3,
            email="Hamza@gmial.com",
            message="This comment is reply comment to this blog",
            name="Hamza",
            IsReply="1",
            comment_reply_Id=1,
            Date="20/1/2008"
        },
            new comments
        {
            blog_Id=2,
            comment_Id=2,
            email="Asma@gmial.com",
            message="This comment is for blog 2",
            name="Rimsha",
            IsReply="0",
            comment_reply_Id=0,
            Date="20/1/2008"
        },
        };
        
        List<Blog> bloglist = new List<Blog>
        {
            new Blog
            (
               1,
              "Rimsha Ishtiaq",
              "12/3/20",
              "Health Care Pakistan",
               input
               //blog_comments = commentlist.FindAll(x=>x.blog_Id==1 && x.IsReply=="0"),
               //comments_reply = commentlist.FindAll(x=>x.comment_reply_Id==x.comment_Id && x.IsReply=="0")
              
              
            ),
            new Blog
            (
               2,
               "Asma Riaz Malik",
              "22/12/19",
              "Legal Care Pakistan",
                input
               //blog_comments = new List<comments>
               //{
               //    new comments
               //    {
               //        comment_Id=2,
               //        email="asmariaz@gmail.com",
               //        name="Asma Riaz",
               //        message="this blog is written by Rimsha ",
               //        blog_Id=2
               //    }
               //}
            )
        };

        
        /* User View */
        public ActionResult posts(string search,int? page){

            List<Blog> dummybloglist = new List<Blog>();
            dummybloglist = bloglist;
            foreach (var item in dummybloglist)
            {
                item.Blog_Content = StripHTML(input);

            }
            if (!string.IsNullOrEmpty(search))
            {
                return View(dummybloglist.Where(x =>
                               x.Date.ToUpper().Contains(search.ToUpper()) ||
                               x.Title.ToUpper().Contains(search.ToUpper()) ||
                               x.Blog_Content.ToUpper().Contains(search.ToUpper())
                           ).ToPagedList(page ?? 1, 10));
            }
            else
            {
                return View(dummybloglist.FindAll(x => x.Deleted == "0").ToPagedList(page ?? 1, 10));
            }

        }

        public ActionResult post(int Id){
            ViewBag.LinkText = "blog";
           
            // string content = "<h2 class=""mb - 3"" style=""font - family: Poppins, Arial, sans - serif; line - height: 1.5; color: rgba(0, 0, 0, 0.8); "">It is a long established fact a reader be distracted</h2><p style="color: rgb(128, 128, 128); font - family: Poppins, Arial, sans - serif; font - size: 16px; "><i><u>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis, eius mollitia suscipit, quisquam doloremque distinctio perferendis et doloribus unde architecto optio laboriosam porro adipisci sapiente officiis nemo accusamus ad praesentium? Esse minima nisi et. Dolore perferendis, enim praesentium omnis, iste doloremque quia officia optio deserunt molestiae voluptates soluta architecto tempora.</u></i></p><p style="color: rgb(128, 128, 128); font - family: Poppins, Arial, sans - serif; font - size: 16px; ">Molestiae cupiditate inventore animi, maxime sapiente optio, illo est nemo veritatis repellat sunt doloribus nesciunt! Minima laborum magni reiciendis qui voluptate quisquam voluptatem soluta illo eum ullam incidunt rem assumenda eveniet eaque sequi deleniti tenetur dolore amet fugit perspiciatis ipsa, odit. Nesciunt dolor minima esse vero ut ea, repudiandae suscipit!</p><h2 class="mb - 3 mt - 5" style="font - family: Poppins, Arial, sans - serif; line - height: 1.5; color: rgba(0, 0, 0, 0.8); ">#2. Creative WordPress Themes</h2><p style="color: rgb(128, 128, 128); font - family: Poppins, Arial, sans - serif; font - size: 16px; "><span style="font - weight: bolder; ">Temporibus ad error suscipit exercitationem hic molestiae totam obcaecati rerum, eius aut, in. Exercitationem atque quidem tempora maiores ex architecto voluptatum aut officia doloremque. Error dolore voluptas, omnis molestias odio dignissimos culpa ex earum nisi consequatur quos odit quasi repellat qui officiis reiciendis incidunt hic non? Debitis commodi aut, adipisci</span>.</p>";
            Blog blogview = bloglist.FirstOrDefault(x => x.blog_Id == Id);
            //Blog blogview = new Blog();
            // blogview.Blog_Content = "<h2 class=\"mb-3\" style=\"font-family: Poppins, Arial, sans-serif; line-height: 1.5; color: rgba(0, 0, 0, 0.8);\">It is a long established fact a reader be distracted</h2><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\"><i><u>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis, eius mollitia suscipit, quisquam doloremque distinctio perferendis et doloribus unde architecto optio laboriosam porro adipisci sapiente officiis nemo accusamus ad praesentium? Esse minima nisi et. Dolore perferendis, enim praesentium omnis, iste doloremque quia officia optio deserunt molestiae voluptates soluta architecto tempora.</u></i></p><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\">Molestiae cupiditate inventore animi, maxime sapiente optio, illo est nemo veritatis repellat sunt doloribus nesciunt! Minima laborum magni reiciendis qui voluptate quisquam voluptatem soluta illo eum ullam incidunt rem assumenda eveniet eaque sequi deleniti tenetur dolore amet fugit perspiciatis ipsa, odit. Nesciunt dolor minima esse vero ut ea, repudiandae suscipit!</p><h2 class=\"mb-3 mt-5\" style=\"font-family: Poppins, Arial, sans-serif; line-height: 1.5; color: rgba(0, 0, 0, 0.8);\">#2. Creative WordPress Themes</h2><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\"><span style=\"font-weight: bolder;\">Temporibus ad error suscipit exercitationem hic molestiae totam obcaecati rerum, eius aut, in. Exercitationem atque quidem tempora maiores ex architecto voluptatum aut officia doloremque. Error dolore voluptas, omnis molestias odio dignissimos culpa ex earum nisi consequatur quos odit quasi repellat qui officiis reiciendis incidunt hic non? Debitis commodi aut, adipisci</span>.</p>";
            return View(blogview);
            
        }

        /* Admin View*/
        public ActionResult all_posts(){
            ViewBag.LinkText = "blog";
            List<Blog> dummybloglist = new List<Blog>();
            dummybloglist = bloglist;
            foreach(var item in dummybloglist)
            {
                item.Blog_Content = StripHTML(input);

            }
            return View(dummybloglist.FindAll(x=>x.Deleted=="0"));
        }
        [HttpGet]
        public ActionResult blog_post(int Id){
            ViewBag.LinkText = "blog";
           // int blog_id = 1;
           // string content = "<h2 class=""mb - 3"" style=""font - family: Poppins, Arial, sans - serif; line - height: 1.5; color: rgba(0, 0, 0, 0.8); "">It is a long established fact a reader be distracted</h2><p style="color: rgb(128, 128, 128); font - family: Poppins, Arial, sans - serif; font - size: 16px; "><i><u>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis, eius mollitia suscipit, quisquam doloremque distinctio perferendis et doloribus unde architecto optio laboriosam porro adipisci sapiente officiis nemo accusamus ad praesentium? Esse minima nisi et. Dolore perferendis, enim praesentium omnis, iste doloremque quia officia optio deserunt molestiae voluptates soluta architecto tempora.</u></i></p><p style="color: rgb(128, 128, 128); font - family: Poppins, Arial, sans - serif; font - size: 16px; ">Molestiae cupiditate inventore animi, maxime sapiente optio, illo est nemo veritatis repellat sunt doloribus nesciunt! Minima laborum magni reiciendis qui voluptate quisquam voluptatem soluta illo eum ullam incidunt rem assumenda eveniet eaque sequi deleniti tenetur dolore amet fugit perspiciatis ipsa, odit. Nesciunt dolor minima esse vero ut ea, repudiandae suscipit!</p><h2 class="mb - 3 mt - 5" style="font - family: Poppins, Arial, sans - serif; line - height: 1.5; color: rgba(0, 0, 0, 0.8); ">#2. Creative WordPress Themes</h2><p style="color: rgb(128, 128, 128); font - family: Poppins, Arial, sans - serif; font - size: 16px; "><span style="font - weight: bolder; ">Temporibus ad error suscipit exercitationem hic molestiae totam obcaecati rerum, eius aut, in. Exercitationem atque quidem tempora maiores ex architecto voluptatum aut officia doloremque. Error dolore voluptas, omnis molestias odio dignissimos culpa ex earum nisi consequatur quos odit quasi repellat qui officiis reiciendis incidunt hic non? Debitis commodi aut, adipisci</span>.</p>";
            Blog blogview = bloglist.FirstOrDefault(x => x.blog_Id == Id);
            //Blog blogview = new Blog();
           // blogview.Blog_Content = "<h2 class=\"mb-3\" style=\"font-family: Poppins, Arial, sans-serif; line-height: 1.5; color: rgba(0, 0, 0, 0.8);\">It is a long established fact a reader be distracted</h2><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\"><i><u>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis, eius mollitia suscipit, quisquam doloremque distinctio perferendis et doloribus unde architecto optio laboriosam porro adipisci sapiente officiis nemo accusamus ad praesentium? Esse minima nisi et. Dolore perferendis, enim praesentium omnis, iste doloremque quia officia optio deserunt molestiae voluptates soluta architecto tempora.</u></i></p><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\">Molestiae cupiditate inventore animi, maxime sapiente optio, illo est nemo veritatis repellat sunt doloribus nesciunt! Minima laborum magni reiciendis qui voluptate quisquam voluptatem soluta illo eum ullam incidunt rem assumenda eveniet eaque sequi deleniti tenetur dolore amet fugit perspiciatis ipsa, odit. Nesciunt dolor minima esse vero ut ea, repudiandae suscipit!</p><h2 class=\"mb-3 mt-5\" style=\"font-family: Poppins, Arial, sans-serif; line-height: 1.5; color: rgba(0, 0, 0, 0.8);\">#2. Creative WordPress Themes</h2><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\"><span style=\"font-weight: bolder;\">Temporibus ad error suscipit exercitationem hic molestiae totam obcaecati rerum, eius aut, in. Exercitationem atque quidem tempora maiores ex architecto voluptatum aut officia doloremque. Error dolore voluptas, omnis molestias odio dignissimos culpa ex earum nisi consequatur quos odit quasi repellat qui officiis reiciendis incidunt hic non? Debitis commodi aut, adipisci</span>.</p>";
            return View(blogview);
        }

        [HttpGet]
        public ActionResult blog_edit(int Id)
        {
          
            ViewBag.LinkText = "edit blog";
            // int blog_id = 1;
            // string content = "<h2 class=""mb - 3"" style=""font - family: Poppins, Arial, sans - serif; line - height: 1.5; color: rgba(0, 0, 0, 0.8); "">It is a long established fact a reader be distracted</h2><p style="color: rgb(128, 128, 128); font - family: Poppins, Arial, sans - serif; font - size: 16px; "><i><u>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis, eius mollitia suscipit, quisquam doloremque distinctio perferendis et doloribus unde architecto optio laboriosam porro adipisci sapiente officiis nemo accusamus ad praesentium? Esse minima nisi et. Dolore perferendis, enim praesentium omnis, iste doloremque quia officia optio deserunt molestiae voluptates soluta architecto tempora.</u></i></p><p style="color: rgb(128, 128, 128); font - family: Poppins, Arial, sans - serif; font - size: 16px; ">Molestiae cupiditate inventore animi, maxime sapiente optio, illo est nemo veritatis repellat sunt doloribus nesciunt! Minima laborum magni reiciendis qui voluptate quisquam voluptatem soluta illo eum ullam incidunt rem assumenda eveniet eaque sequi deleniti tenetur dolore amet fugit perspiciatis ipsa, odit. Nesciunt dolor minima esse vero ut ea, repudiandae suscipit!</p><h2 class="mb - 3 mt - 5" style="font - family: Poppins, Arial, sans - serif; line - height: 1.5; color: rgba(0, 0, 0, 0.8); ">#2. Creative WordPress Themes</h2><p style="color: rgb(128, 128, 128); font - family: Poppins, Arial, sans - serif; font - size: 16px; "><span style="font - weight: bolder; ">Temporibus ad error suscipit exercitationem hic molestiae totam obcaecati rerum, eius aut, in. Exercitationem atque quidem tempora maiores ex architecto voluptatum aut officia doloremque. Error dolore voluptas, omnis molestias odio dignissimos culpa ex earum nisi consequatur quos odit quasi repellat qui officiis reiciendis incidunt hic non? Debitis commodi aut, adipisci</span>.</p>";
            Blog blogview = bloglist.FirstOrDefault(x => x.blog_Id == Id);
            //Blog blogview = new Blog();
            // blogview.Blog_Content = "<h2 class=\"mb-3\" style=\"font-family: Poppins, Arial, sans-serif; line-height: 1.5; color: rgba(0, 0, 0, 0.8);\">It is a long established fact a reader be distracted</h2><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\"><i><u>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis, eius mollitia suscipit, quisquam doloremque distinctio perferendis et doloribus unde architecto optio laboriosam porro adipisci sapiente officiis nemo accusamus ad praesentium? Esse minima nisi et. Dolore perferendis, enim praesentium omnis, iste doloremque quia officia optio deserunt molestiae voluptates soluta architecto tempora.</u></i></p><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\">Molestiae cupiditate inventore animi, maxime sapiente optio, illo est nemo veritatis repellat sunt doloribus nesciunt! Minima laborum magni reiciendis qui voluptate quisquam voluptatem soluta illo eum ullam incidunt rem assumenda eveniet eaque sequi deleniti tenetur dolore amet fugit perspiciatis ipsa, odit. Nesciunt dolor minima esse vero ut ea, repudiandae suscipit!</p><h2 class=\"mb-3 mt-5\" style=\"font-family: Poppins, Arial, sans-serif; line-height: 1.5; color: rgba(0, 0, 0, 0.8);\">#2. Creative WordPress Themes</h2><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\"><span style=\"font-weight: bolder;\">Temporibus ad error suscipit exercitationem hic molestiae totam obcaecati rerum, eius aut, in. Exercitationem atque quidem tempora maiores ex architecto voluptatum aut officia doloremque. Error dolore voluptas, omnis molestias odio dignissimos culpa ex earum nisi consequatur quos odit quasi repellat qui officiis reiciendis incidunt hic non? Debitis commodi aut, adipisci</span>.</p>";
            return View(blogview);
        }

        [HttpPost]
        public ActionResult blog_edit(Blog blog)
        {
           
            if (blog.Blog_Content == "" || blog.Blog_Content == null)
            {
                ModelState.AddModelError("Blog_Content", "blog content is required");
                return View(blog);
            }
            else
            {
                bloglist = new List<Blog>();

                //blog.blog_Id = Int32.Parse(Guid.NewGuid().ToString());
                bloglist.Add(blog);
                //save here in database
            }
            return RedirectToAction("all_posts", "blog");
        }

        public ActionResult comments(){
            int Id = 1;
            // string content = "<h2 class=""mb - 3"" style=""font - family: Poppins, Arial, sans - serif; line - height: 1.5; color: rgba(0, 0, 0, 0.8); "">It is a long established fact a reader be distracted</h2><p style="color: rgb(128, 128, 128); font - family: Poppins, Arial, sans - serif; font - size: 16px; "><i><u>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis, eius mollitia suscipit, quisquam doloremque distinctio perferendis et doloribus unde architecto optio laboriosam porro adipisci sapiente officiis nemo accusamus ad praesentium? Esse minima nisi et. Dolore perferendis, enim praesentium omnis, iste doloremque quia officia optio deserunt molestiae voluptates soluta architecto tempora.</u></i></p><p style="color: rgb(128, 128, 128); font - family: Poppins, Arial, sans - serif; font - size: 16px; ">Molestiae cupiditate inventore animi, maxime sapiente optio, illo est nemo veritatis repellat sunt doloribus nesciunt! Minima laborum magni reiciendis qui voluptate quisquam voluptatem soluta illo eum ullam incidunt rem assumenda eveniet eaque sequi deleniti tenetur dolore amet fugit perspiciatis ipsa, odit. Nesciunt dolor minima esse vero ut ea, repudiandae suscipit!</p><h2 class="mb - 3 mt - 5" style="font - family: Poppins, Arial, sans - serif; line - height: 1.5; color: rgba(0, 0, 0, 0.8); ">#2. Creative WordPress Themes</h2><p style="color: rgb(128, 128, 128); font - family: Poppins, Arial, sans - serif; font - size: 16px; "><span style="font - weight: bolder; ">Temporibus ad error suscipit exercitationem hic molestiae totam obcaecati rerum, eius aut, in. Exercitationem atque quidem tempora maiores ex architecto voluptatum aut officia doloremque. Error dolore voluptas, omnis molestias odio dignissimos culpa ex earum nisi consequatur quos odit quasi repellat qui officiis reiciendis incidunt hic non? Debitis commodi aut, adipisci</span>.</p>";
            Blog blogview = bloglist.FirstOrDefault(x => x.blog_Id == Id);
            //Blog blogview = new Blog();
            // blogview.Blog_Content = "<h2 class=\"mb-3\" style=\"font-family: Poppins, Arial, sans-serif; line-height: 1.5; color: rgba(0, 0, 0, 0.8);\">It is a long established fact a reader be distracted</h2><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\"><i><u>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis, eius mollitia suscipit, quisquam doloremque distinctio perferendis et doloribus unde architecto optio laboriosam porro adipisci sapiente officiis nemo accusamus ad praesentium? Esse minima nisi et. Dolore perferendis, enim praesentium omnis, iste doloremque quia officia optio deserunt molestiae voluptates soluta architecto tempora.</u></i></p><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\">Molestiae cupiditate inventore animi, maxime sapiente optio, illo est nemo veritatis repellat sunt doloribus nesciunt! Minima laborum magni reiciendis qui voluptate quisquam voluptatem soluta illo eum ullam incidunt rem assumenda eveniet eaque sequi deleniti tenetur dolore amet fugit perspiciatis ipsa, odit. Nesciunt dolor minima esse vero ut ea, repudiandae suscipit!</p><h2 class=\"mb-3 mt-5\" style=\"font-family: Poppins, Arial, sans-serif; line-height: 1.5; color: rgba(0, 0, 0, 0.8);\">#2. Creative WordPress Themes</h2><p style=\"color: rgb(128, 128, 128); font-family: Poppins, Arial, sans-serif; font-size: 16px;\"><span style=\"font-weight: bolder;\">Temporibus ad error suscipit exercitationem hic molestiae totam obcaecati rerum, eius aut, in. Exercitationem atque quidem tempora maiores ex architecto voluptatum aut officia doloremque. Error dolore voluptas, omnis molestias odio dignissimos culpa ex earum nisi consequatur quos odit quasi repellat qui officiis reiciendis incidunt hic non? Debitis commodi aut, adipisci</span>.</p>";
           
            return View(blogview);
        }

        //[HttpPost]
        //public ActionResult comments(int Id,int b_Id)
        //{
        //    int a = 0;
        //    return View();
        //}
        public ActionResult write_blog(){
            ViewBag.LinkText = "blog";
          //  bloglist = new List<Blog>();

            return View();
        }
        [HttpPost]
        public ActionResult write_blog(Blog blog, string Date)
        {
            blog.Date = Date;
            blog.Deleted = "0";
            if (blog.Blog_Content == "" || blog.Blog_Content == null)
            {
                ModelState.AddModelError("Blog_Content", "blog content is required");
                return View(blog);
            }
            else
            {
                bloglist = new List<Blog>();
                
                //blog.blog_Id = Int32.Parse(Guid.NewGuid().ToString());
                bloglist.Add(blog);
              //save here in database
            }
            return RedirectToAction("all_posts","blog");
        }

        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        public string delete_blog(int EmployeeId)
        {
            string result;
            Blog bg = bloglist.Where(x => x.blog_Id == EmployeeId).SingleOrDefault();
          
            if (bg != null)
            {
                bg.Deleted = "1";
              

                result = "1";
            }
            else
            {
                result = "0";
            }

            return result;
        }


        //comments from all users
        public string Comments_Save(int BlogId, string Message,string Name,string Email)
        {
            comments cm = new comments();
            cm.blog_Id = BlogId;
            cm.comment_Id = commentlist.Count;
            cm.comment_reply_Id = 0;
            cm.Date = DateTime.Now.ToString();
            cm.IsReply = "0";
            cm.message = Message;
            cm.name = Name;
            cm.email = Email;
            commentlist.Add(cm);


            if (BlogId != null)
            {
                Blog blogview = bloglist.FirstOrDefault(x => x.blog_Id == BlogId);
                blogview.blog_comments = commentlist.FindAll(x => x.blog_Id == BlogId && x.IsReply == "0");
                blogview.blog_comments = getReplyComments(blogview.blog_comments);


                //  return View(blogview);
                return "1";
                //return RedirectToAction("comments", "blog", blogview);


            }


            return "0";
        }



        //comment reply from admin
        public string Save_Comments(int CommentId,int BlogId,string Message)
        {
            comments cm = new comments();
            cm.blog_Id = BlogId;
            cm.comment_Id = commentlist.Count;
            cm.comment_reply_Id = CommentId;
            cm.Date = DateTime.Now.ToString();
            cm.IsReply = "1";
            cm.message = Message;
            cm.name = "Admin";
            cm.email = "Admin@dsds";
            commentlist.Add(cm);
            

            if(BlogId != null)
            {
                Blog blogview = bloglist.FirstOrDefault(x => x.blog_Id == BlogId);
                blogview.blog_comments = commentlist.FindAll(x => x.blog_Id == BlogId && x.IsReply == "0");
                blogview.blog_comments = getReplyComments(blogview.blog_comments);


                //  return View(blogview);
                return "1";
                //return RedirectToAction("comments", "blog", blogview);


            }


            return "0";
        }

        public List<comments> getReplyComments(List<comments> blog_comments)
        {
            foreach (var comments in blog_comments)
            {
                
                comments.replyList = commentlist.FindAll(x => x.comment_reply_Id == comments.comment_Id);
              
            }
            return blog_comments;
        }

    }
}