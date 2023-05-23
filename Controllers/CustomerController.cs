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
        //Initialise DbContext via constructor to access SQLSeverDB
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


        //Form for new customer deets
        public ActionResult CustomerForm()
        {
            var membershipType = _context.MembershipTypes.ToList();
            //viewmodel object instantitiate to hold customer + membership properties
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipType = membershipType
            };

            return View("CustomerForm",viewModel);
        }


        
        //Upon submit of newform, redirect user to customer page which will now list the new customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCustomerForm(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //Refactor suggestion: Use a mapper class and call it as the main object class for customer param
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        // EDIT EXISTING CUSTOMER FORM
        public ActionResult EditForm(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            //Checks if customer returned exist in our database.
            if(customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipTypes.ToList()
            };
            //returns to the customerform page but now will be filled with the customer details from the database.
            return View("CustomerForm", viewModel);
        }

        // Load customer page
        public ActionResult Index()
        {
            //Not passing domain model anymore as we are relying on API calls
            //var customers = _context.Customers.Include(c => c.MembershipType);

            return View();
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
