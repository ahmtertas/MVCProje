using Business.Concrete;
using Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Message = Entities.Concrete.Message;


namespace MVCProje.Controllers
{

    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            var messageList = messageManager.GetListInbox();
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            var messageList = messageManager.GetListSendbox();
            return View(messageList);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var messageValues = messageManager.GetById(id);
            return View(messageValues);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var messageValues = messageManager.GetById(id);
            return View(messageValues);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            var messageList = messageManager.GetListSendbox();
            return View(messageList);
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            message.SenderMail = "aliyildiz@gmail.com";
            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            messageManager.MessageAdd(message);
            return RedirectToAction("Sendbox");
        }

        public PartialViewResult MessageListMenu() 
        {
            return PartialView();
        }

    }
}