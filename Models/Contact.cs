using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeedaniLegalCare.Models
{
    public class Contact
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "email is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "email is required")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "email is required")]
        public string Message { get; set; }
        [Required(ErrorMessage = "email is required")]
        public string Date { get; set; }
    }
}