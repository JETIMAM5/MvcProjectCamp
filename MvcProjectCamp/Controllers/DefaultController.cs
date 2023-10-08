using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class DefaultController : Controller
    {

        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        // GET: Default

        [AllowAnonymous]
        public ActionResult Headings()
        {
            var HeadingList=hm.GetList();
            return View(HeadingList);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}