using System;
using System.Collections;
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
            var customer = GetCustomers();
            return View(customer);
        }

        public ActionResult Details(int Id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();
            else
                return View(customer);
        }
        
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Name = "Pragya Singh", Id = 1 },
                new Customer { Name = "Anmol Agarwal", Id = 2}
            };
        }
        
    }
}