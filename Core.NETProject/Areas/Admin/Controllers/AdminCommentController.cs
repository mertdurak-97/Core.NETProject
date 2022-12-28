using BusinessLayer.Concrete;
using Core.NETProject.Areas.Admin.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core.NETProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCommentController : Controller
    {
        CommentManager cm = new CommentManager(new EFCommentRepository());

        private readonly UserManager<AppUser> _userManager;

        public AdminCommentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("Admin/[Controller]/[Action]/{id?}")]
        public IActionResult Index()
        {
            var values = cm.GetCommentListWithBlog();
            return View(values);
        }

        [Route("Admin/[Controller]/[Action]/{id?}")]
        public IActionResult DeleteComment(int id)
        {
            var value = cm.GetCommentId(id);
            cm.DeleteComment(value);
            return RedirectToAction("Index");
        }
    }
}

