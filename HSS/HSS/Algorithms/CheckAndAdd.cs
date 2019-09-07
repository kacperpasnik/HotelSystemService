using HSS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSS.Algorithms
{
    public abstract class CheckAndAdd
    {
        private static HSSContext db = new HSSContext();
        private static List<DateTime> ListOfAllDates = new List<DateTime>();
        private static List<DateTime> DatesInOneReservation = new List<DateTime>();

        public static bool CheckDays(DateTime StartDate, DateTime EndDate, int room)
        {
            DownloadData(room);
            TimeSpan differrent = EndDate.Subtract(StartDate);
            DateTime copy;
            int days = (int)differrent.TotalDays;
            for (int i = ListOfAllDates.Count/2; i > 0; i--)
            {
                AttachToListOfOneReservation(i);
                copy = StartDate;
                for (int j = 0; j < days; j++)
                {
                    copy.AddDays(j);
                    foreach (var x in DatesInOneReservation)
                    {
                        if (copy.Equals(x))
                        {
                            ListOfAllDates.Clear();
                            DatesInOneReservation.Clear();
                            return false;
                        }
                           
                    }
                }
                DatesInOneReservation.Clear();
            }
            return true;
        }

        private static void DownloadData(int room)
        {
            foreach(var x in db.Customer.Where(x => x.Room==room))
            {
                ListOfAllDates.Add(x.Date_from);
                ListOfAllDates.Add(x.Date_to);
            }
        }

        private static void AttachToListOfOneReservation(int ReservationNumber)
        {
            //RoomForReservation = db.Customer.Where(x => x.Date_from == ListOfAllDates[ReservationNumber * 2 - 2]).ToString();
            if (ListOfAllDates[ReservationNumber * 2 - 2].Equals(ListOfAllDates[ReservationNumber * 2 - 1]))
            {
                DatesInOneReservation.Add(ListOfAllDates[ReservationNumber * 2 - 2]);
            }
            else
            {
                TimeSpan Dates = ListOfAllDates[ReservationNumber * 2 - 1].Subtract(ListOfAllDates[ReservationNumber * 2 - 2]);
                int limit = (int)Dates.TotalDays;
                for (int i=0;i<limit; i++)
                {
                    DatesInOneReservation.Add(ListOfAllDates[ReservationNumber * 2 - 2].AddDays(i));
                }
                
            }
        }


    }


}