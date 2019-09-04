using HSS.DAL;
using HSS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HSS.Controllers
{
    public class HomeController : Controller
    {
        //private HSSContext database = new HSSContext();
        public ActionResult Index()
        {
            //DateTime datetest = new DateTime(2001, 1, 1);
            //Customer test = new Customer { Name = "Adam", Surname = "Kowalski", Date_from = datetest, Date_to = datetest, Room = 1 };
            //database.Customer.Add(test);
            //database.SaveChanges();
            return View();
        }
    }
}