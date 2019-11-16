using HSS.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HSS.DAL
{
    public class HSSContext : IdentityDbContext<ApplicationUser>
    {
        public HSSContext() : base("HSSContext")
        {

        }

        public static HSSContext Create()
        {
            return new HSSContext();
        }
        public DbSet<Customer> Customer { get; set; }

        public System.Data.Entity.DbSet<HSS.Models.Account> Accounts { get; set; }
    }
}