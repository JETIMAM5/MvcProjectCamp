using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;


namespace MvcProjectCamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EFContentDal());
        DataAccessLayer.Concrete.Context c = new DataAccessLayer.Concrete.Context();
        public ActionResult MyContent(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentvalues = cm.GetListByWriter(writeridinfo);
            return View(contentvalues);

        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d=id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID=writeridinfo;
            content.ContentStatus = true;
            cm.ContentAdd(content);
            return RedirectToAction("MyContent");
        }
    
    }
}