using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;
using X.PagedList;

namespace Core.NETProject.Controllers
{

    public class BlogController : Controller
    {

        BlogManager bm = new BlogManager(new EFBlogRepository());
        Context c = new Context();
        [AllowAnonymous]
        public IActionResult Index(int page = 1)
        {
            var values = bm.GetBlogListWithCategory().ToPagedList(page, 6);
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = bm.ListWithCategoryByWriter(writerID);
            return View(values);
        }



        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager cm = new CategoryManager(new EFCategoryRepository());
            List<SelectListItem> categoryvalues = (from x in cm.ListAllCategory()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }


        [HttpPost]
        public IActionResult BlogAdd(Blog p, IFormFile image)
        {


            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userId = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();


            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);

            string fileName = null;
            string fileExtension = null;
            string filePath = null;
            bool saveFile = false;
            if (image != null && image.Length > 0)
            {
                fileName = image.FileName;
                fileExtension = Path.GetExtension(fileName);
                saveFile = true;
            }
            if (saveFile)
            {
                fileName = Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "") + fileExtension;

                filePath = Path.Combine("wwwroot", "web", "images", fileName);

            }
            p.BlogImage = fileName;
            if (saveFile)
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.CreateNew))
                {
                    image.CopyTo(fileStream);
                }
            }
            p.BlogStatus = true;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.UserId = userId;
            bm.AddBlog(p);
            return RedirectToAction("BlogListByWriter", "Blog");

        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.GetBlogId(id);
            bm.DeleteBlog(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            CategoryManager cm = new CategoryManager(new EFCategoryRepository());
            List<SelectListItem> categoryvalues = (from x in cm.ListAllCategory()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;

            var blogvalue = bm.GetBlogId(id);
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult UpdateBlog(Blog p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            p.BlogStatus = true;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            bm.UpdateBlog(p);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
