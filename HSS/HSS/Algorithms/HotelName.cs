using HSS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HSS.Algorithms
{
    abstract public class HotelName
    {
        private static HSSContext db = new HSSContext();
        static public string GetHotelName(string userName)
        {

            //string userName = User.Identity.GetUserName();
            var allIds = db.Users.Where(x => x.UserName == userName).ToList();
            string hotelName = allIds[0].HotelName;
            return hotelName;
        }
    }
}