using HSS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSS.DAL
{
    public class HSSContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Room> Room { get; set; }

    }
}
