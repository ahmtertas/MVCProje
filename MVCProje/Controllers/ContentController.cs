using Business.Concrete;
using Data.Concrete;
using Data.EntityFramework;
using Entities.Concrete;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content

        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult GetContent(string content)
        {
            var values = contentManager.GetListByContent(content);
            return View(values);
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.GetListByHeadingId(id);
            return View(contentValues);
        }

    }
}