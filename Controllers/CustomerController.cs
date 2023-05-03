using blackBox.Models;
using blackBox.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blackBox.Controllers
{
    public class CustomerController : Controller
    {

        // Load customer page
        public ActionResult Customers()
        {
            var customers = GetCusomters();

            return View(customers);
        }

        public ActionResult Direct(int? id)
        {
            //assign var to id value
            var customer = GetCusomters().SingleOrDefault(param => param.Id == id);
            //check if id is null
            if (customer == null)
            {
                return HttpNotFound("Customer Id not found in our server!");
            }
            //return view(var)
            return View(customer);
        }


        //IEnumerable to store list of customer
        private IEnumerable<Customer> GetCusomters()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Tyson Nguyen" },
                new Customer { Id = 2, Name = "Julie Lam"}
            };
        }


        //Custom url routing example
        //Movie/released/{year:regex(\\d{4}):range(1940,2023)}/{month:regex(\\d{2}):range(1,12)}
        //[Route("Customers/Detail/{Id")]
        //public ActionResult CustomerIdDisplay(int year, int month)
        //{

        //    return Content(String.Format("year={0} | month={1}", year, month));
        //}
    }
}
