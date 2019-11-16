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

        [Display(Name="First name")]
        [Required(ErrorMessage = "Enter the first name of the customer")]
        [StringLength(25)]
        public string Name { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Enter the second name of the customer")]
        [StringLength(50)]
        public string Surname { get; set; }

        [Display(Name = "Starting day")]
        [Required(ErrorMessage = "Enter the date of the first day")]
        [DataType(DataType.Date,ErrorMessage = "Enter a day in format dd.mm.yyyy")]
        public DateTime Date_from { get; set; }

        [Display(Name = "Ending day")]
        [Required(ErrorMessage = "Enter the date of the last day")]
        [DataType(DataType.Date, ErrorMessage = "Enter a day in format dd.mm.yyyy")]
        public DateTime Date_to { get; set; }

        [Display(Name = "Room number")]
        [Required(ErrorMessage = "Enter the room number")]
        [Range(1,999,ErrorMessage = "Insert number between 1 and 999")]
        public int Room { get; set; }
        [ScaffoldColumn(false)]
        public string HotelName { get; set; }

    }
}