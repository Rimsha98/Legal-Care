using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SeedaniLegalCare.Models
{
    public class Blog
    {
        public int blog_Id { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be >2 and <50 letters")]
        [Required(ErrorMessage = "author name is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "date is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string Date { get; set; }

        [Required(ErrorMessage = "blog title is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "must be >2 and <100 letters")]
        public string Title { get; set; }

        [AllowHtml]
       
        [StringLength(1000,MinimumLength = 100, ErrorMessage = "must be >100 letters")]
        public string Blog_Content { get; set; }
        public List<comments> blog_comments { get; set; }
        public string Deleted { set; get; }

       
       


        static List<comments> commentlist = new List<comments> {

        new comments
        {
            blog_Id=1,
            comment_Id=1,
            email="Rimsha@gmial.com",
            message="This comment is for blog 1",
            name="Rimsha",
            IsReply="0",
            comment_reply_Id=0
        },
            new comments
        {
            blog_Id=1,
            comment_Id=2,
            email="Hamza@gmial.com",
            message="This comment is reply comment to this blog",
            name="Hamza",
            IsReply="1",
            comment_reply_Id=1
        }, new comments
        {
            blog_Id=1,
            comment_Id=3,
            email="Hamza@gmial.com",
            message="This comment is reply comment to this blog",
            name="Hamza",
            IsReply="1",
            comment_reply_Id=1
        }, new comments
        {
            blog_Id=2,
            comment_Id=4,
            email="Asma@gmial.com",
            message="This comment is for blog 2",
            name="Rimsha",
            IsReply="0",
            comment_reply_Id=0
        },
        };
        public Blog(int blogId,string Authorname,string Date,string Title,string Blogcontent)
        {
            this.blog_Id = blogId;
            this.Author = Authorname;
            this.Title = Title;
            this.Blog_Content = Blogcontent;
            this.Date = Date;
            this.blog_comments = commentlist.FindAll(x => x.blog_Id == blogId && x.IsReply=="0");
            this.Deleted = "0";
            
            getReplyComments(blog_comments);
           // this.comments_reply = commentlist.FindAll(x => x.comment_reply_Id == this.blog_comments.comment_Id && x.IsReply == "1");
        }

        public void getReplyComments(List<comments> blog_comments)
        { 
            foreach(var comments in blog_comments)
            {
                //if(comments.IsReply=="0")
                //{
                   // this.comments_reply = blog_comments.FindAll(x => x.comment_reply_Id == comments.comment_Id);
                    //comments.replyList = new List<comments>
                    //{
                    //    new comments(comments.comment_Id)
                    //};
                comments.replyList = commentlist.FindAll(x => x.comment_reply_Id == comments.comment_Id);
                //}
            }

        }
    }
}