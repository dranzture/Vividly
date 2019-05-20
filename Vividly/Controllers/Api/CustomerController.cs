using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using Vividly.DTOs;
using Vividly.Models;

namespace Vividly.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/customer
        public IHttpActionResult GetCustomers(string query = null)
        {

            var customersQuery = _context.Customers
                .Include(c => c.MembershipType); 

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.FirstName.Contains(query) || c.LastName.Contains(query));
            var customers = customersQuery.ToList();
            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>);


            //for(int i=0;i<customers.Count && i < customerDtos.ToList().Count; i++)
            //{
            //    customerDtos.ToList()[i].ID = customers[i].ID;
            //}

            return Ok(customerDtos);
        }

        // GET /api/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customer == null)
                return NotFound();
            var customerDTO = Mapper.Map<Customer, CustomerDTO>(customer);
            customerDTO.ID = customer.ID;
            return Ok(customerDTO);
        }
        // POST /api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDTO.ID = customer.ID;
            return Created(new Uri(Request.RequestUri+ "/" + customer.ID), customerDTO);
        }

        // PUT /api/customer/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerInDb = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customerInDb == null)
                return NotFound();
            Mapper.Map(customerDTO, customerInDb);         
            _context.SaveChanges();

            return Ok("Updated");
        }
        // DELETE /api/customer/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customerInDb == null)
                return BadRequest();
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
