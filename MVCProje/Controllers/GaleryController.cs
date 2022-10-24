using Business.Concrete;
using Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class GaleryController : Controller
    {
        ImageFileManager imageFileManager = new ImageFileManager( new EfImageFileDal());
        // GET: Galery
        public ActionResult Index()
        {
            var imageFileValues = imageFileManager.GetList();
            return View(imageFileValues);
        }
    }
}