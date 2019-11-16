using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HSS.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter Login.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Enter Password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember account")]
        public bool RememberAcc { get; set; }

    }
}