using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HSS.Models
{
    public class Account
    {
        [ScaffoldColumn(false)]
        public int AccountId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Login must have at least 3 characters.")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string HotelName { get; set; }

    }
}