using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.ViewModels;

namespace MyProject.Controllers
{
    public class CustomersController : Controller
    {
        public ActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        private List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Tom Coffey" },
                new Customer { Id = 2, Name = "Nicolas Cage" }
            };
        }




    }

}



