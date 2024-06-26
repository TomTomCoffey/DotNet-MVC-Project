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
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            // if (!ModelState.IsValid)
            // {
            //     var viewModel = new NewCustomerViewModel
            //     {
            //         Customer = customer,
            //         MembershipTypes = _context.MembershipType!.ToList()
            //     };

            //     return View("CustomerForm", viewModel);
            // }
            if (customer.Id == 0)
            {
                _context.Customers?.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers?.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
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
                MembershipTypes = _context.MembershipType!.ToList()
            };

            return View("CustomerForm", viewModel);
        }


    }

}



