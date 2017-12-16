using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeWatch.Models;

namespace WeWatch.Controllers
{
    public class CustomersController : Controller
    {

        // Declare a context for my database
        private ApplicationDbContext _context;     


        // Constructor required for context initialization
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }

        // GET: Customer
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();  // "Include" extension used to help with "Eager Loading" for the index view
        
            return View(customers);
        }


        // GET: Customer/Details/id
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

    }
}