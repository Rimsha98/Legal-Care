using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeedaniLegalCare.Models
{
    public class Attorney
    {
        public int Attorney_ID { get; set; }

        [Required(ErrorMessage = "name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be >2 and <50 letters")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "name must contain alphabets only")]

        public string Attorney_Name { get; set; }

        [Required(ErrorMessage = "email is required")]
        [EmailAddress(ErrorMessage = "email must be in correct format")]
        public string Attorney_Email { get; set; }

        [Required(ErrorMessage = "password is required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "must be >6 and <20 characters")]

        public string Attorney_Password { get; set; }

        [Required(ErrorMessage = "password is required")]
        [Compare("Attorney_Password", ErrorMessage = "Passwords do not match!")]

        public string Attorney_ConfirmPassword { get; set; }

        public string Attorney_Country { get; set; }
        
        [Required(ErrorMessage = "city is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be >2 and <50 letters")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "city must contain alphabets only")]
        public string Attorney_City { get; set; }
       
        [Required(ErrorMessage = "contact number is required")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "digits >7 and <12 required")]
        public string Attorney_Number { get; set; }
        public string Attorney_Gender { get; set; }

        [Required(ErrorMessage = "date of birth is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string Attorney_DOB { get; set; }

        [Required(ErrorMessage = "experience is required")]
        [StringLength(2, MinimumLength = 1, ErrorMessage = "digits < 2 required")]
        public string Attorney_Experience { get; set; }

        [Required(ErrorMessage = "educational information is required")]
        [StringLength(100, MinimumLength = 7, ErrorMessage = "must be >7 and <100 letters")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "education must contain alphabets only")]
        public string Attorney_Education { get; set; }

        [Required(ErrorMessage = "experience is required")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "digits  < 10 required")]
        public string Attorney_Cases { get; set; }
        public string Attorney_Role { get; set; }
        
        [Required(ErrorMessage = "firm is required")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "must be >7 and <50 letters")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "firm must contain alphabets only")]
        public string Attorney_Firm { get; set; }

        [Required(ErrorMessage = "language information is required")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "must be >7 and <50 letters")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "language must contain alphabets only")]

        public string Attorney_Languages { get; set; }

        [Required(ErrorMessage = "certification information is required")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "must be >7 and <50 letters)")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "certificate must contain alphabets only")]
        public string Attorney_Certification { get; set; }
        public string Attorney_Image { get; set; }
        public string Approved { get; set; }
        public string Block { get; set; }
        public string Deleted { get; set; }
    }
}