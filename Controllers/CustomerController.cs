using blackBox.Models;
using blackBox.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace blackBox.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            // Need to initialise the property to use dbContext disposable object. 
            _context = new ApplicationDbContext();
        }
        //to remove the disposable dbcontext object
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Load customer page
        public ActionResult Customers()
        {
            var customers = _context.Customers.Include(c => c.MembershipType);

            return View(customers);
        }

        public ActionResult Direct(int? id)
        {
            //assign var to id value
            var customer = _context.Customers.SingleOrDefault(param => param.Id == id);
            //check if id is null
            if (customer == null)
            {
                return HttpNotFound("Customer Id not found in our server!");
            }
            //return view(var)
            return View(customer);
        }

        //public IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer> 
        //    {
        //        new Customer {Id = 1, Name = "Tyson Ng", IsSubscribedToNewsletter = true, MembershipTypeId = 1},
        //        new Customer {Id = 2, Name = "Julie Lam", IsSubscribedToNewsletter = true, MembershipTypeId = 0}

        //    };
        //}


        //Custom url routing example
        //Movie/released/{year:regex(\\d{4}):range(1940,2023)}/{month:regex(\\d{2}):range(1,12)}
        //[Route("Customers/Detail/{Id")]
        //public ActionResult CustomerIdDisplay(int year, int month)
        //{

        //    return Content(String.Format("year={0} | month={1}", year, month));
        //}
    }
}
