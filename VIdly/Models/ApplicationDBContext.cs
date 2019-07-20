using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VIdly.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> Membershiptypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}