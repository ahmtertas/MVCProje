using Business.Concrete;
using Data.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult GetCategoryList()
        {
            var categoryValues = categoryManager.GetList();
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {

            categoryManager.CategoryAdd(category);
            //İstenilen sayfaya döndürüyoruz.
            return RedirectToAction("Deneme");
        }

        public ActionResult Deneme()
        {
            var categoryValues = categoryManager.GetList();
            return View(categoryValues);
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryValues = categoryManager.GetById(id);
            categoryManager.CategoryDelete(categoryValues);
            return RedirectToAction("Deneme");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = categoryManager.GetById(id);
            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            categoryManager.CategoryUpdate(category);
            return RedirectToAction("Deneme");
        }
    }
}