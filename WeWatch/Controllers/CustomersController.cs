using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeWatch.Models;

namespace WeWatch.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        public ViewResult Index()
        {
            var customers = GetCustomers();
        
            return View(customers);
        }


        // GET: Customer/Details/id
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "James Brown"},
                new Customer {Id = 2, Name = "Tyler King"}
            };
        }
    }
}