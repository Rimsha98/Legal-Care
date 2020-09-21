using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeedaniLegalCare.Models
{
    public class Client
    {
        public int Client_ID { get; set; }

        [Required(ErrorMessage = "name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be >2 and <50 letters")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "name must contain alphabets only")]

        public string Client_Name { get; set; }

        [Required(ErrorMessage = "email is required")]
        [EmailAddress(ErrorMessage = "email must be in correct format")]
        public string Client_Email { get; set; }

        [Required(ErrorMessage = "password is required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "must be >6 and <20 characters")]
       
        public string Client_Password { get; set; }

        [Required(ErrorMessage = "password is required")]
        [Compare("Client_Password", ErrorMessage = "Passwords do not match!")]
        
        public string Client_ConfirmPassword { get; set; }
        public string Client_Country { get; set; }

        [Required(ErrorMessage = "city is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be >2 and <50 letters")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "city must contain alphabets only")]
        public string Client_City { get; set; }

        [Required(ErrorMessage = "contact number is required")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "digits >7 and <12 required)")]
        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "numbers only")]
        public string Client_Number { get; set; }
        public string Client_Gender { get; set; }

       
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        public string Client_Image { get; set; }
        public string Approved { get; set; }
        public string Block { get; set; }
        public string Deleted { get; set; }


        

        
       
    }
}