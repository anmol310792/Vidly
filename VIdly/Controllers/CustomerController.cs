using System.Linq;
using System.Web.Mvc;
using VIdly.Models;
using System.Data.Entity;
using VIdly.ViewModels;
using System;

namespace VIdly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CustomerController()
        {
            _context = new ApplicationDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.Membershiptypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customers = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {                
                var customerModel = new CustomerFormViewModel
                {
                    Customers = viewModel.Customers,
                    MembershipTypes = _context.Membershiptypes.ToList()
                };
                return View("CustomerForm", customerModel);
            }

            if (viewModel.Customers.Id == 0)
            {
                _context.Customers.Add(viewModel.Customers);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == viewModel.Customers.Id);

                customerInDb.Name = viewModel.Customers.Name;
                customerInDb.Birthdate = viewModel.Customers.Birthdate;
                customerInDb.MembershipType = viewModel.Customers.MembershipType;
                customerInDb.IsSubscribedToNewsLetter = viewModel.Customers.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customers = customer,
                MembershipTypes = _context.Membershiptypes
            };
            return View("CustomerForm", viewModel);
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customer = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customer);
        }

        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();
            else
                return View(customer);
        }       
    }
}