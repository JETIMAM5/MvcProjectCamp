using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MvcProjectCamp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EFContactDal());
        ContactValidator cv = new ContactValidator();

        public ActionResult Index()
        {

            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult ContactDetails(int id)
        {
            var contactvalues = cm.GetById(id);
            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu(Message message)
        {
            using (var db = new Context())
            {
                var InboxCount = db.Messages.Where(x => x.ReceiverMail == "admin@gmail.com").Count();
                var ContactCount = db.Contacts.Count();
                ViewBag.inboxcount = InboxCount;
                ViewBag.contactcount = ContactCount;
            }
            return PartialView();
        }
    }
}