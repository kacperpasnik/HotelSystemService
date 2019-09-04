using HSS.DAL;
using HSS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSS.ViewModels
{
    public class ManageViewModel
    {
        public IEnumerable<Customer> Tuples { get; set; }
        //public List<Customer> Query { get; set; }

    }
}