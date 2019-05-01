using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vividly.Models;
using Vividly.View_Models;

namespace Vividly.Controllers
{
    public class CustomerController : Controller
    {
        //Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var dbCustomers = _context.Customers.Include(c=>c.MembershipType).ToList();
            CustomersViewModel Customers = new CustomersViewModel();
            Customers.Customers = dbCustomers;                                 
            return View(Customers);
        }
        public ActionResult New()
        {
            return View();
        }
        [Route("Customer/Details/{id}")]
        public ActionResult Details(int id)
        {
            Customer customer = _context.Customers.Include(c => c.MembershipType).Where(s => s.ID == id).FirstOrDefault();
            if (customer != null)
            {
                return View(customer);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}