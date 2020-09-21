using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeedaniLegalCare.Models
{
    public class Network
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public int Attorney_ID { get; set; }
        public string Attorney_Name { get; set; }
        public string Attorney_Role { get; set; }
        public string Connection_Date { get; set; }

    }
}