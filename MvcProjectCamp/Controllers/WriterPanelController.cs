﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        
        Context c = new Context();

        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
           string  p = (string)Session["WriterMail"];
            id = c.Writers.Where(x => x.WriterMail == p && x.WriterStatus == true ).Select(y => y.WriterID).FirstOrDefault();
            var writervalue = wm.GetById(id);
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator writervalidator = new WriterValidator();
            ValidationResult result = writervalidator.Validate(writer);
            if (result.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("AllHeading","WriterPanel");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }

            return RedirectToAction("Index");
        }

        public ActionResult MyHeading(string p)
        {

            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            var values = hm.GetListByWriter(writeridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {

            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;

            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();

            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writeridinfo;
            heading.HeadingStatus = true;
            hm.HeadingAdd(heading);
            return RedirectToAction("MyHeading");

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
            var headingvalues = hm.GetById(id);
            return View(headingvalues);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = hm.GetById(id);
            if (headingvalue.HeadingStatus == true)
            {
                headingvalue.HeadingStatus = false;
                hm.HeadingDelete(headingvalue);
            }
            else
            {
                headingvalue.HeadingStatus = true;
                hm.HeadingDelete(headingvalue);
            }
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int page = 1)
        {
            var headings = hm.GetList().ToPagedList(page, 4);
            return View(headings);

        }
    }
}