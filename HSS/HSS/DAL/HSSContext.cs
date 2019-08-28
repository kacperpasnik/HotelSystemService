using HSS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HSS.DAL
{
    public class HSSContext : DbContext
    {
        public HSSContext() : base("HSSContext")
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Room> Room { get; set; }

    }
}