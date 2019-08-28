using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HSS.Models
{
    public class Room
    {
        public int Id_Room { get; set; }
        [Required(ErrorMessage = "Enter the Reservation day")]
        public List<int> ReservationDay { get; set; }
        [Required(ErrorMessage = "Enter the room number")]
        public int RoomNumber { get; set; }
        public int Id_customer { get; set; }

    }
}