using Business.Concrete;
using Data.Concrete;
using Data.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        Context context = new Context();
        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(string writerMail)
        {
            writerMail = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(x => x.WriterMail == writerMail).Select(y => y.WriterId).FirstOrDefault();
            var values = headingManager.GetListByWriter(writerId);
            return View(values);

        }

        public ActionResult NewHeading()
        {
            
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writerMailInfo = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(x => x.WriterMail == writerMailInfo).Select(y => y.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.HeadingStatus = true;
            heading.WriterId = writerId;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");

        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var headingValue = headingManager.GetById(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = 1;
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var currentHeading = headingManager.GetById(id);
            currentHeading.HeadingStatus = false;
            headingManager.HeadingUpdate(currentHeading);
            return RedirectToAction("MyHeading");
        }
    }
}