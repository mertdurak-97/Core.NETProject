using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.NETProject.Controllers
{

    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());

        [AllowAnonymous]
        public IActionResult Index()
        {
            Context c = new Context();

            var username = User.Identity?.Name;
            ViewBag.v = username;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userId = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();

            ViewBag.v1 = c.Blogs?.Count().ToString();
            ViewBag.v2 = c.Blogs?.Where(x => x.UserId == userId).Count();
            ViewBag.v3 = c.Categorys?.Count().ToString();
            return View();
        }



    }
}
