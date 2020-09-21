using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeedaniLegalCare.Models
{
    public class Section
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string Image_Position { get; set; }

        public string Heading { get; set; }
        public string Heading_Color { get; set; }
        public string Text { get; set; }
        public string Link_Title { get; set; }
        public string Link_Url { get; set; }
        public string Link_Color { get; set; }
    }
}