using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthorizeandAuthenticate.Models
{
    public class UserModel 
    {
        [Required(ErrorMessage = "Please Enter User Name")]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Email-Id")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Password")]
        public string UserPassword{ get; set; }

        [Required(ErrorMessage = "Please Enter Role")]
        [Display(Name = "Role")]
        public string Role { get; set; }

        public int IsValid { get; set; }
        public string LoginErrorMessage { get; set; }
    }
}