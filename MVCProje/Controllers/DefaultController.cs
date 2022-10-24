using Business.Concrete;
using Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Headings()
        {
            var headingList = headingManager.GetList();
            return View(headingList);
        }
    }
}