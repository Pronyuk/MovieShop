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
        List<Customer> customers = new List<Customer>()
            {
                new Customer() { Id = 1, Name = "John Smith"},
                new Customer() { Id = 2, Name = "Mary Williams" }
            };

        // GET: Customers
        public ActionResult ShowAllCutomers()
        {
            var viewModel = new ShowAllCustomersViewModel()
            {
                Customers = customers
            };
            return View(viewModel);
        }

        //[Route()]
        public ActionResult CustomerPage(int Id)
        {
            var customer = customers.FirstOrDefault((c) => c.Id == Id);
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