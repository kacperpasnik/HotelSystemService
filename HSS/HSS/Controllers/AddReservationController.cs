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
            return View();
        }
    }
}