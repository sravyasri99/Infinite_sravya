using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC_Prj.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }

        //1. Mormal Method
        public string NormalMethod()
        {
            return "Hi All..";
        }

        public ViewResult ViewMethod()
        {
            return View() ;
        }

        //3. Content Result

        public ContentResult ContentMethod()
        {
            return Content("Hello all, This is Content");
            //return Content("<h1 style ")
        }

        public EmptyResult Empty()
        {
            int amt = 45000;
            float si = (amt * 3 * 2) / 100;
            return new EmptyResult();
        }

        //5. Redirect

        //public RedirectResult redirectMethod()
        //{
        //    return RedirectToAction("ContentMethod");
        //}

        //public ActionResult FirstTempRequest()
        //{
        //    List<string> stationeries = new List<string>()
        //    {
        //        "pens", "pencils", "Notebooks","Markers", ""
        //    };
        //}
    }
}