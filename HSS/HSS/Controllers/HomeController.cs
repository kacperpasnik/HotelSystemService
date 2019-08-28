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
        private HSSContext database = new HSSContext();
        public ActionResult Index()
        {
          
    
            return View();
        }
    }
}