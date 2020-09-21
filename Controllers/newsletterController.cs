using SeedaniLegalCare.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SeedaniLegalCare.Controllers{
    public class newsletterController : Controller{
        string color_heading = "black", color_link="red";
        private string ImageLeft(){
            TagBuilder section = new TagBuilder("div");
            section.AddCssClass("image-left container-fluid p-0");

            TagBuilder row = new TagBuilder("div");
            row.AddCssClass("row no-gutters");

            TagBuilder col_left = new TagBuilder("div");
            col_left.AddCssClass("col-md-4 p-0");

            TagBuilder image = new TagBuilder("img");
            image.Attributes.Add("alt", "newsletter image");
            image.Attributes.Add("src", "/images/bg_2.jpg");
            image.AddCssClass("img-fluid");

            TagBuilder col_right = new TagBuilder("div");
            col_right.AddCssClass("col-md-8 p-4");

            TagBuilder heading = new TagBuilder("h1");
            heading.Attributes.Add("style", "color: "+color_heading);
            heading.AddCssClass("heading");
            heading.InnerHtml = "Ali Ahmed has joined the team";

            TagBuilder text = new TagBuilder("p");
            text.AddCssClass("parah");
            text.InnerHtml = "Lorem Ipsum is simply dummy t essentially unchanged. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled.";

            TagBuilder link = new TagBuilder("a");
            link.Attributes.Add("href", "http://www.google.com.pk");
            link.Attributes.Add("style","color: "+color_link);
            link.AddCssClass("linkstyle");
            link.InnerHtml = "www.google.com.pk";

            col_left.InnerHtml += image;
            col_right.InnerHtml += heading;
            col_right.InnerHtml += text;
            col_right.InnerHtml += link;

            row.InnerHtml += col_left;
            row.InnerHtml += col_right;

            section.InnerHtml += row;

            return section.ToString();
        }

        private string ImageRight()
        {
            TagBuilder section = new TagBuilder("div");
            section.AddCssClass("image-right container-fluid p-0");

            TagBuilder row = new TagBuilder("div");
            row.AddCssClass("row no-gutters");

            TagBuilder col_left = new TagBuilder("div");
            col_left.AddCssClass("col-md-4 p-0");

            TagBuilder image = new TagBuilder("img");
            image.Attributes.Add("alt", "newsletter image");
            image.Attributes.Add("src", "/images/person_2.jpg");
            image.AddCssClass("img-fluid");

            TagBuilder col_right = new TagBuilder("div");
            col_right.AddCssClass("col-md-8 p-4");

            TagBuilder heading = new TagBuilder("h1");
            heading.Attributes.Add("style", "color: " + color_heading);
            heading.AddCssClass("heading");
            heading.InnerHtml = "Ali Ahmed has joined the team";

            TagBuilder text = new TagBuilder("p");
            text.AddCssClass("parah");
            text.InnerHtml = "Lorem Ipsum is simply dummy t essentially unchanged. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled. <br> Lorem Ipsum is simply dummy t essentially unchanged. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled. <br> Lorem Ipsum is simply dummy t essentially unchanged. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled.";

            TagBuilder link = new TagBuilder("a");
            link.Attributes.Add("href", "http://www.google.com.pk");
            link.Attributes.Add("style", "color: " + color_link);
            link.AddCssClass("linkstyle");
            link.InnerHtml = "www.google.com.pk";

            col_left.InnerHtml += image;
            col_right.InnerHtml += heading;
            col_right.InnerHtml += text;
            col_right.InnerHtml += link;

            row.InnerHtml += col_right;
            row.InnerHtml += col_left;
            

            section.InnerHtml += row;

            return section.ToString();
        }

        private List<string> Create_Section(){

            List<string> elements = new List<string>();
            elements.Add(ImageLeft());
            elements.Add(ImageRight());
            elements.Add(ImageLeft());

            return elements;
        }

        public ActionResult news(){
            return View(Create_Section());
        }

        public ActionResult newsletter(){
            return View();
        }

        public ActionResult list()
        {
            ViewBag.LinkText = "newsletter";
            return View();
        }

        [HttpGet]
        public ActionResult compose_newsletter()
        {
            ViewBag.LinkText = "newsletter";
            return View();
        }

        [HttpPost]
        public ActionResult compose_newsletter(IList<Section> sections)
        {
            return View();
        }

        //   [HttpPost]
        /*   public ActionResult compose_newsletter(HttpPostedFileBase image, Section blue, string[] text, string[] select, string[] heading, string[] color, string[] linktext, string[] linkurl, string[] link)
           {
               List<Section> sections = new List<Section>();
               Section temp = new Section();
               var allowedExtensions = new[] {
               ".Jpg", ".png", ".jpg", "jpeg"
           };
               var fileName = Path.GetFileName(image.FileName);
               var ext = Path.GetExtension(image.FileName);
               if (allowedExtensions.Contains(ext))
               {
                   string name = Path.GetFileNameWithoutExtension(fileName);
                   string myfile = name + "_" + ext;
                   var path = Path.Combine(Server.MapPath("~/Content/NewsletterImages"), myfile);
                   image.SaveAs(path);
                   temp.Image = path;
               }

               temp.Image_Position = select[1];
               temp.Text = text[1];
               temp.Heading = heading[1];
               temp.Heading_Color = color[1];
               temp.Link_Color = link[1];
               temp.Link_Title = linktext[1];
               temp.Link_Url = linkurl[1];

               sections.Add(temp);


               return View();        
           } */
    }
}