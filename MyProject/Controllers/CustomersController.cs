using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.ViewModels;
using System.Linq;
using System.Collections.Generic;


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
            var customers = _context.Customers?.ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers?.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }


    }

}



