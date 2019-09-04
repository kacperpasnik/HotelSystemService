using HSS.DAL;
using HSS.Models;
using HSS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HSS.Controllers
{
   // [RoutePrefix("reservation")]
    public class ManageController : Controller
    {

        private HSSContext db = new HSSContext();
        // [Route]
        public ActionResult Manage(string options, string search)
        {
            var all = db.Customer.ToList();

            if (options == "1")
                all = db.Customer.Where(x => x.CustomerId.ToString() == search || search == null).ToList();
            else if (options == "2")
                all = db.Customer.Where(x => x.Name.StartsWith(search) || search == null).ToList();
            else if (options == "3")
                all = db.Customer.Where(x => x.Surname.StartsWith(search) || search == null).ToList();
            else if (options == "4")
                all = db.Customer.Where(x => x.Date_from.ToString() == search || search == null).ToList();
            else if (options == "5")
                all = db.Customer.Where(x => x.Date_to.ToString() == search || search == null).ToList();
            else if (options == "6")
                all = db.Customer.Where(x => x.Room.ToString() == search || search == null).ToList();

            ManageViewModel vm = new ManageViewModel()
            {
                Tuples = all
            };

            return View(vm);
        }

    }
}