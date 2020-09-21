using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeedaniLegalCare.Models
{
    public class Login
    {
        public int user_Id { get; set; }
        
        [Required]
        public string Email { get; set; }


        [Required]
       
        public string Password { get; set; }
        public string Account_type { get; set; }
        public string Account_Id { get; set; }
    }
}