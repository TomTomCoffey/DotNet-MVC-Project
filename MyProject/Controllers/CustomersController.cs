using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.ViewModels;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;


namespace MyProject.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers?.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers?.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        public ActionResult New()
        {

            var membershipTypes = _context.MembershipType?.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes!
            };

            return View("CustomerForm", viewModel);

        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            Console.WriteLine("Customer Name: " + customer.Name);
            _context.Customers?.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers?.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType?.ToList()
            };

            return View("CustomerForm", viewModel);
        }


    }

}



