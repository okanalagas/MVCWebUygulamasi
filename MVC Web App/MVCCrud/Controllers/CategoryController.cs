using MVCCrud.DesignPatterns.SingletonPattern;
using MVCCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrud.Controllers
{
    public class CategoryController : Controller
    {
        NorthwindEntities _db;
        public CategoryController()
        {
            _db = DBTool.DBInstance;
        }
        public ActionResult ListCategories()
        {
            return View(_db.Categories.ToList());
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }
        public ActionResult EditCategory(int id) 
        {
            Category categoryToBeUpdated = _db.Categories.Find(id);
            return View(categoryToBeUpdated);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            Category categoryToBeUpdated = _db.Categories.Find(category.CategoryID);
            categoryToBeUpdated.CategoryName = category.CategoryName;
            categoryToBeUpdated.Description= category.Description;
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }
        public ActionResult DeleteCategory(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            return RedirectToAction("ListCategories"); 
        }
    }
}