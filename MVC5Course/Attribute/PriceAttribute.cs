using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Attribute
{
    public class 取得價格下拉式選單 : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            FabricsEntities db = new FabricsEntities();
             var items = new List<SelectListItem>();
            var price_list = (from p in db.Product
                              select new
                              {
                                  value = p.Price,
                                  Text = p.Price
                              }).Distinct().OrderBy(p => p.value);
            filterContext.Controller.ViewBag.Price = new SelectList(price_list, "Value", "Text");
        }
    }
}