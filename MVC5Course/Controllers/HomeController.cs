using MVC5Course.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {
        //[LocalOnly]
        [ShowDate]
        public ActionResult Index()
        {
            return View();
        }
       // [LocalOnly]
        [ShowDate]
        public ActionResult About()
        {
          //  ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult VT()
        {

            return PartialView();
        }
        public ActionResult MetroIndex()
        {

            return View();
        }
    }
}