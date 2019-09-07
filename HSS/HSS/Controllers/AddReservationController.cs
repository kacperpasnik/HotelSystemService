using HSS.Algorithms;
using HSS.DAL;
using HSS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HSS.Controllers
{
    [RoutePrefix("reservation2")]
    public class AddReservationController : Controller
    {
        // GET: AddRoom
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [Route]
        public ActionResult Add()
        {
            //ViewBag.Message = "test";
            return View();
        }

        [HttpPost]
        public ActionResult Add(Customer customer)
        {
            ViewBag.Number = 0;
            if (customer.Date_from.CompareTo(customer.Date_to) == 1)
            {
                ViewBag.Message = "Invalid date! The starting date cannot be later than the ending date.";
                return View("Add", customer);
            }
            else
            {
                if (!CheckAndAdd.CheckDays(customer.Date_from, customer.Date_to, customer.Room))
                {
                    ViewBag.Message = "The chosen date is already resereved for this room.";
                    return View("Add", customer);
                }
                else
                {
                    if (!ModelState.IsValid)
                        return View("Add", customer);
                    else
                    {
                        HSSContext db = new HSSContext();
                        db.Customer.Add(customer);
                        db.SaveChanges();
                        ViewBag.Message = "Reservation has been added successfully!";
                        ViewBag.Number = 1;
                        return View("Add");
                    }
                }
            }
        }
    }
}