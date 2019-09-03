using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HSS.Controllers
{
    [RoutePrefix("reservation")]
    public class ManageController : Controller
    {
        // GET: Manage
        [Route]
        public ActionResult Manage()
        {
            return View();
        }
    }
}