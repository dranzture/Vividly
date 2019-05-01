using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vividly.Models;
using Vividly.View_Models;

namespace Vividly.Controllers
{
    public class CustomerController : Controller
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer{ ID=1, FirstName="Polat", LastName="Coban" },
            new Customer{ ID=2, FirstName="Ashley", LastName="Coban" }
        };
        // GET: Customer
        public ActionResult Index()
        {
            CustomersViewModel Customers = new CustomersViewModel();
            Customers.Customers = customers;                                 
            return View(Customers);
        }

        [Route("customer/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = customers.Where(s => s.ID == id).First();
            return View(customer);
        }
    }
}