using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
       

        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal());
        // GET: Default

        
        public ActionResult Headings()
        {
            var HeadingList=hm.GetList();
            return View(HeadingList);
        }
        public PartialViewResult Index(int id = 0)
        {
            var contentlist = cm.GetListByHeadingId(id);
            return PartialView(contentlist);
        }
    }
}