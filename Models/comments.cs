using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeedaniLegalCare.Models
{
    public class comments
    {
        public int comment_Id { get; set; }
        public int blog_Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string message { get; set; }
        public string IsReply{ get; set; }
        public string Date{ get; set; }
        public int comment_reply_Id{ get; set; }
        public List<comments> replyList { get; set; }

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

        public comments()
        {

        }
        public comments(int comment_Id)
        {
           this.replyList= commentlist.FindAll(x => x.comment_reply_Id == comment_Id);
        }

    }
}