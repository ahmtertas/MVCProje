using Business.Concrete;
using Data.Concrete;
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
        Context context = new Context();
        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            var writerMail = (string)Session["WriterMail"];
            var messageList = messageManager.GetListInbox(writerMail);
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            var writerMail = (string)Session["WriterMail"];
            var messageList = messageManager.GetListSendbox(writerMail);
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
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var writerMail = (string)Session["WriterMail"];
            message.SenderMail = writerMail;
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