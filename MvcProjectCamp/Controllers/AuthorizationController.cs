
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
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adm = new AdminManager(new EFAdminDal());
        public ActionResult Index()
        {
            var adminvalues = adm.GetList();
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adm.AdminAdd(admin);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminvalue = adm.GetById(id);
            return View(adminvalue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            adm.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}