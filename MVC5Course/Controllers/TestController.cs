using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using Omu.ValueInjecter;

namespace MVC5Course.Controllers
{
    public class TestController : BaseController
    {

       
        // GET: Test
        public ActionResult Index()
        {
           
            var data = repo.Get所有未刪除商品資料TOP10() 
;
            return View(data);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Product data)
        {
            if (ModelState.IsValid)
            {
                repo.Add(data);
                repo.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(data);
        }
        public ActionResult Edit(int id)
        {
            var item = repo.Find(id);
            
            return View(item);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id ,Product data)
        {
            if (ModelState.IsValid)
            {
             
                var item = repo.Find(id);
                item.InjectFrom(data);
                repo.SaveChanges();
                TempData["ProductItem"] = item;
                return RedirectToAction("Index");
            }

            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var item = repo.Find(id);
            item.IsDeleted = true;
            // db.OrderLine.RemoveRange(item.OrderLine.ToList());
            //db.Product.Remove(item);
            repo.SaveChanges();

            return RedirectToAction("Index");
        }

        

        public ActionResult Details(int id)
        {
            var item =repo.Find(id);

            return View(item);
        }

    }
}