﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedMe.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator validationRules = new ContactValidator();
        //[Authorize]
        // GET: Contact
        public ActionResult Index()
        {

            var contactValues = contactManager.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {

            var contactValues = contactManager.GetById(id);
            return View(contactValues);
        }
        public PartialViewResult ContactPartial()
        {

            var result = contactManager.GetList().Count();
            ViewBag.vlc = result;
            var sendMail = messageManager.ListInbox().Count();
            ViewBag.sendMail = sendMail;
            var inMail = messageManager.ListSendBox().Count();
            ViewBag.inMail = inMail;
            return PartialView();
        }
    }
}