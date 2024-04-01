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


    }

}



