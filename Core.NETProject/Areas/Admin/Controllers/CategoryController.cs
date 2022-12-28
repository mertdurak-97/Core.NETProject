using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;


namespace Core.NETProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());

        [Route("Admin/[Controller]/[Action]/{id?}")]
        public IActionResult Index(int page = 1)
        {
            var values = cm.ListAllCategory().ToPagedList(page, 3);
            return View(values);
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [Route("Admin/[Controller]/[Action]")]
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {

            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {
                p.CategoryStatus = true;
                cm.AddCategory(p);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [Route("Admin/[Controller]/[Action]/{id?}")]
        public IActionResult CategoryDelete(int id)
        {
            var value = cm.GetCategoryId(id);
            cm.DeleteCategory(value);
            return RedirectToAction("Index");
        }
    }

}
