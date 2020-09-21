using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeedaniLegalCare.Models{
    public class Feedback{
        public int Feedback_ID { get; set; }
        public int Client_ID { get; set; }
        public string Client_Name { get; set; }
        public string Client_Email { get; set; }
        public string Client_Feedback { get; set; }
        public string Date { get; set; }
        public string Attorney_ID { get; set; }
        public int Client_Rating { get; set; }

    }
}