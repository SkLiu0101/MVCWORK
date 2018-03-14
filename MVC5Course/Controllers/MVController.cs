using MVC5Course.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MVController : BaseController
    {
        // GET: MV
        public ActionResult Index()
        {
         var data = repo.Get所有未刪除商品資料TOP10();
            ViewData.Model = data;
            ViewBag.pageTitle = "商品清單";
            //ViewBag["pagetitle"] = "商品清單2";
            return View(data);
        }
        [HttpPost]
        [HandleError(ExceptionType = typeof(DbEntityValidationException), View = "Error_DbEntityValidationException")]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(ProductsListVM[] datas)
        {
            if (ModelState.IsValid)
            {
                foreach (ProductsListVM productVM in datas)
                {
                    var one = repo.Find(productVM.ProductId);
                    one.Active = productVM.Active;
                    one.Stock = productVM.Stock;
                    one.Price = productVM.Price;
                }
                    repo.UnitOfWork.Commit();
     
                return RedirectToAction("Index");
            }
            var data = repo.Get所有未刪除商品資料TOP10();
            ViewData.Model = data;
            ViewBag.pageTitle = "商品清單";
            //ViewBag["pagetitle"] = "商品清單2";

            return View(data);
        }
    }
}