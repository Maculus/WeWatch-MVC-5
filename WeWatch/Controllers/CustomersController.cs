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
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer {Name = "John Doe"},
                new Customer {Name = "John Brown"}
            };
        
            return View(customers);
        }
    }
}