using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using blackBox.Models;
using blackBox.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace blackBox.Controllers.Api
{
    public class CustomersController : ApiController
    {
        //Instantiate db object
        private ApplicationDbContext _context { get; set; }

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //1 GET List<CustomerDto> GetCustomers()  URL: ~/api/customers
        public IHttpActionResult GetCustomers()
        {
            var customers = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customers);
        }

        //2 GET a customer GetACustomer() URL: ~/api/customers/1
        public IHttpActionResult GetACustomer(int id)
        {
            var customerDto = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerDto == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customerDto));
        }

        //3 POST CreateCustomer CreateCustomers(Customer customer) URL: ~/api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //map client object data to domain db
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            //return the assigned id generated in SQLdb to client data model
            customerDto.Id = customer.Id;
            return Created(Request.RequestUri + "/" + customer.Id, customerDto);
        }

        //4 PUT EditCustomer(int id, Customer customer) URL: ~/api/customers/1
        [HttpPut]
        public IHttpActionResult EditCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            //AutoMapper used to assign customers in SQLDb with customerDTO values.
            Mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();
            return Ok(customerDto);// <== continue work here 
        } 

        //5 DELETE RemoveCustomer(int id)URL: ~/api/customers/1
        [HttpDelete]
        //CURRENT ISSUE: id returned from btn click on modal is returning id = null 
        public IHttpActionResult RemoveCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return Ok();
        }
    }
}
