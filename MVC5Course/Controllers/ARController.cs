using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialViewTest()
        {

            return PartialView("index");
        }
        public ActionResult ContentTest()
        {

            return View();
        }
        public ActionResult ContentTest_Better()
        {

            return PartialView("JSAleartResirect","新增成功");
        }
        public ActionResult FileTest(string dl)
        {
            if (string.IsNullOrEmpty(dl))
            {
                return File(Server.MapPath("~/App_Data/writing_header.jpg"), "image/jpeg");
            }
            else
            {
                return File(Server.MapPath("~/App_Data/writing_header.jpg"), "image/jpeg","googleformimg.jpg");
            }
        }
        public ActionResult jsonTest()
        {
            var date = from p in repo.All()
                       select new
                       {
                           p.ProductId,
                           p.ProductName,
                           p.Price
                       };


            return Json(date, JsonRequestBehavior.AllowGet);
        }
    }
}