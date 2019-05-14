using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
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
        public IHttpActionResult GetCustomers()
        {
            
            var customersInDb = _context.Customers
                .Include(c=>c.MembershipType)
                .ToList();
            List<CustomerDTO> customerDTOs = new List<CustomerDTO>();
            foreach(var customer in customersInDb)
            {
                var customersDTO = Mapper.Map<Customer, CustomerDTO>(customer);
                customersDTO.ID = customer.ID;
                customerDTOs.Add(customersDTO);

            }
            return Ok(customerDTOs);
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
