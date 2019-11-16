using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HSS.ViewModels
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Insert Login.")]
        [MinLength(3, ErrorMessage = "Login must have at least 3 characters.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Insert Password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Insert Password again.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confrim Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfrimPassword { get; set; }
        [Required(ErrorMessage = "Insert the name of your Hotel.")]
        [MinLength(2, ErrorMessage = "The Hotel name must have at least 2 characters")]
        [Display(Name = "Hotel name")]
        public string HotelName { get; set; }
    }
}