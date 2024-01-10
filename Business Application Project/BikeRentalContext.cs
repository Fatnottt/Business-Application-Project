using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BikeRental.Models
{
    public class BikeRentalContext : DbContext
    {
        public BikeRentalContext() : base("name=BikeRentalContext")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
