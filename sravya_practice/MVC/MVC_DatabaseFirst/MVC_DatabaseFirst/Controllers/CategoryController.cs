using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_DatabaseFirst.Models;

namespace MVC_DatabaseFirst.Controllers
{
    public class CategoryController : Controller
    {
        northwindEntities db = new northwindEntities();

        // GET: Category
        public ActionResult Index()
        {
            List<Category> catlist = db.Categories.ToList();
            return View(catlist);
        }
    }
}