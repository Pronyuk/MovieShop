using MoviewShop.Models;
using MoviewShop.ViewModels;
using System;
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

        public ActionResult ShowAllCutomers()
        {
            var customers = _context.Customers.ToList();
            var viewModel = new ShowAllCustomersViewModel()
            {
                Customers = customers
            };
            return View(viewModel);
        }

        //[Route()]
        public ActionResult CustomerPage(int Id)
        {
            var customer = _context.Customers.SingleOrDefault((c) => c.Id == Id);
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