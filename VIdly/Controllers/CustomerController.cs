using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VIdly.Models;

namespace VIdly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customer = new Customer()
            {
                Name = "Pragya"
            };
            return View(customer);
        }
    }
}