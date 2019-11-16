using HSS.DAL;
using HSS.Models;
using HSS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using HSS.Algorithms;

namespace HSS.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {

        private HSSContext db = new HSSContext();
        // [Route]
        public ActionResult Manage(string options, string search)
        {

            string hotelName = HotelName.GetHotelName(User.Identity.GetUserName());
            var all = db.Customer.Where(x=>x.HotelName==hotelName).ToList();

            if (options == "1")
                all = db.Customer.Where(x => x.Name.StartsWith(search) && x.HotelName==hotelName || search == null).ToList();
            else if (options == "2")
                all = db.Customer.Where(x => x.Surname.StartsWith(search) && x.HotelName == hotelName || search == null).ToList();
            else if (options == "3")
                all = db.Customer.Where(x => x.Date_from.ToString() == search && x.HotelName == hotelName || search == null).ToList();
            else if (options == "4")
                all = db.Customer.Where(x => x.Date_to.ToString() == search && x.HotelName == hotelName || search == null).ToList();
            else if (options == "5")
                all = db.Customer.Where(x => x.Room.ToString() == search && x.HotelName == hotelName || search == null).ToList();

            ManageViewModel vm = new ManageViewModel()
            {
                Tuples = all
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer= db.Customer.Single(x => x.CustomerId == id);
            string hotelName = HotelName.GetHotelName(User.Identity.GetUserName());
            if (customer.HotelName == hotelName)
            {
                return View(customer);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Edit(Customer customer, int id)
        {
            
            if (ModelState.IsValid)
            {
                HSSContext db = new HSSContext();
                var x = db.Customer.Single(u => u.CustomerId == id);
                x.Name = customer.Name;
                x.Surname = customer.Surname;
                x.Date_from = customer.Date_from;
                x.Date_to = customer.Date_to;
                x.Room = customer.Room;
                db.SaveChanges();
                return RedirectToAction("Manage");
            }
            return View(customer);
        }


        public ActionResult Delete(int id)
        {
            string hotelName = HotelName.GetHotelName(User.Identity.GetUserName());
            var customer = db.Customer.Single(x => x.CustomerId == id);
            if (customer.HotelName == hotelName)
            {
                HSSContext db = new HSSContext();
                var x = db.Customer.First(u => u.CustomerId == id);
                db.Customer.Remove(x);
                db.SaveChanges();
                return View();
            }
            else
                return RedirectToAction("Manage");
        }



    }
}