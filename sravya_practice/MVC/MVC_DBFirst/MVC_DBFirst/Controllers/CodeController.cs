
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_DBFirst.Models;

namespace MVC_DBFirst.Controllers
{
    public class CodeController : Controller
    {
        // GET: Code
        northwindEntities db = new northwindEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustomersInGermany()
        {
            var customer1 = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(customer1);
        }
        public ActionResult CustomerDetails()
        {
            var customer2 = db.Orders.Where(o => o.OrderID == 10248).Select(o => o.Customer).FirstOrDefault();
            return View(customer2);
        }
    }
}
