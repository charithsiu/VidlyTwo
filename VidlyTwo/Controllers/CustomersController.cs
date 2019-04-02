using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyTwo.Models;
using VidlyTwo.ViewModels;
using System.Data.Entity; 

namespace VidlyTwo.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var MembershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = MembershipTypes
            };
            return View( "CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BDate = customer.BDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer =_context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes
            };
            return View("CustomerForm", viewModel);
        }
        // GET: Customers
        public ActionResult Index()
        {
            /*var customers = new List<Customer>
            {
                new Customer{Id = 1, Name = "John Smith"},
                new Customer{Id = 2, Name = "Mary Williams"}
            };

            var customersList = new ListCustomerViewModel
            {
                Customers = customers
            };
            return View(customersList);*/

            var customers = _context.Customers.Include(c => c.MembershipType).ToList() ;
            
            return View(customers);
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int Id)
        {
            /* var customer = new Customer();
             if(Id == 1)
             {
                 customer = new Customer
                 {
                     Id = 1,
                     Name = "John Smith"
                 };
             }
             if(Id == 2)
             {
                 customer = new Customer
                 {
                     Id = 1,
                     Name = "Mary Williams"
                 };
             }
             return View(customer);*/

            var customer = _context.Customers.Include(c=> c.MembershipType).SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);

        }
    }
}