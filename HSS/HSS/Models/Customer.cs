using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HSS.Models
{
    public class Customer
    {
        [ScaffoldColumn(false)]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Enter the name of the customer")]
        [StringLength(25)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter the second name of the customer")]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Enter the date of the first day")]
        public DateTime Date_from { get; set; }
        [Required(ErrorMessage = "Enter the date of the last day")]
        public DateTime Date_to { get; set; }
        [Required(ErrorMessage = "Enter the room number")]
        public int Room { get; set; }

    }
}