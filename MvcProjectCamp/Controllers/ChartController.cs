
using MvcProjectCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart() 
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<Category> BlogList() 
        {
        List <Category> ct = new List<Category>();
            ct.Add(new Category
            {
                CategoryName = "Software",
                CategoryCount = 2
                
            }); ;
            ct.Add(new Category 
            {
                CategoryName="Travel",
                CategoryCount = 3
            });
            ct.Add(new Category
            {
                CategoryName = "Technology",
                CategoryCount = 4
            });
            ct.Add(new Category
            {
                CategoryName = "Sport",
                CategoryCount = 1
            });
            return ct;
        }
    }
}