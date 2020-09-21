using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeedaniLegalCare.Models
{
    public class Article
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "blog title is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "must be >2 and <100 letters")]

        public string Title { get; set; }

        [AllowHtml]
        [StringLength(1000, MinimumLength = 100, ErrorMessage = "must be >100 letters")]

        public string Content { get; set; }
        [Required(ErrorMessage = "date is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]

        public string Date { get; set; }
        
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be >2 and <50 letters")]
        [Required(ErrorMessage = "author name is required")]

        public string Author { get; set; }
        public string Deleted { set; get; }
        public string Approved { set; get; }
        public int Poster_Id { set; get; }
        public string PostedBy { set; get; }


    }
}