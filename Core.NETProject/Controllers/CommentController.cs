using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace Core.NETProject.Controllers
{
	public class CommentController : Controller
	{
		CommentManager cm = new CommentManager(new EFCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult PartialAddComment()
		{
			return PartialView();
		}
		[HttpPost]
		public IActionResult PartialAddComment(Comment p)
		{

			p.CommnetDate = DateTime.Parse(DateTime.Now.ToLongDateString());
			p.CommentStatus = true;
			p.BlogID = p.BlogID;
			cm.AddComment(p);
			return RedirectToAction("BlogReadAll", "Blog", new { id = p.BlogID });
		}
		public IActionResult CommentListByBlog(int id)
		{
			var values = cm.ListAllComment(id);
			return PartialView(values);
		}
	}
}
