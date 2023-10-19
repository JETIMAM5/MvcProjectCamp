using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
       CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        public ActionResult HeadingReport() 
        {
        var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList() ;
            

            List<SelectListItem> valuewriter =(from x in wm.GetList()
                                               select new SelectListItem 
                                               {
                                               Text=x.WriterName + " " + x.WriterSurname,
                                               Value = x.WriterID.ToString()
                                               }).ToList();
            ViewBag.vlw=valuewriter;
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id) 
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var headingvalues= hm.GetById(id);
            return View(headingvalues);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading) 
        {
        hm.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id) 
        {
            var headingvalue=hm.GetById(id);
            if (headingvalue.HeadingStatus==true)
            {
                headingvalue.HeadingStatus = false;
                hm.HeadingDelete(headingvalue);
            }
            else
            {
                headingvalue.HeadingStatus=true;
                hm.HeadingDelete(headingvalue);
            }
            return RedirectToAction("Index");
        }
    }
    
}