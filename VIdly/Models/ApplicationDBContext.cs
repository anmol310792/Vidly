﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VIdly.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}