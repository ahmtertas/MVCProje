using Business.Concrete;
using Data.EntityFramework;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Message = Entities.Concrete.Message;

namespace MVCProje.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Index(string mail)
        {
            var messageList = messageManager.GetListInbox(mail);
            return View(messageList);
        }

        public ActionResult Sendbox(string mail)
        {
            var messageList = messageManager.GetListSendbox(mail);
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
        public ActionResult NewMessage(string mail)
        {
            var messageList = messageManager.GetListSendbox(mail);
            return View(messageList);
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            messageManager.MessageAdd(message);
            return RedirectToAction("Sendbox");
        }



    }
}