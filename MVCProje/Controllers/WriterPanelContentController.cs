using Business.Concrete;
using Data.Concrete;
using Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent(string writerMail)
        {
            writerMail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == writerMail).Select(y => y.WriterId).FirstOrDefault();
            var contentValues = contentManager.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }
    }
}