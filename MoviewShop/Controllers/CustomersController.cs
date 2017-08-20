using MoviewShop.Models;
using MoviewShop.ViewModels;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviewShop.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context { get; set; }

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposign)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershiptypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                MembershipTypes = membershiptypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDB.Name = customer.Name;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.BirthDate = customer.BirthDate;
            }
            _context.SaveChanges();

            return RedirectToAction("ShowAllCutomers", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewCustomerViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult ShowAllCutomers()
        {
            var customers = _context.Customers.Include((c) => c.MembershipType).ToList();
            var viewModel = new ShowAllCustomersViewModel()
            {
                Customers = customers
            };
            return View(viewModel);
        }

        //[Route()]
        public ActionResult CustomerPage(int Id)
        {
            var customer = _context.Customers.Include((a) => a.MembershipType).SingleOrDefault((c) => c.Id == Id);
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