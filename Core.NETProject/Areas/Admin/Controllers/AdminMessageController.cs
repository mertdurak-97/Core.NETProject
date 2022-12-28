using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.NETProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        MessageManager nm = new MessageManager(new EFMessageRepository());
        Context c = new Context();

        public IActionResult Index()
        {

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userId = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = nm.GetInboxByWriter(userId);
            return View(values);

        }
        [Route("Admin/[Controller]/[Action]")]
        public IActionResult Sendbox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userId = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = nm.GetSendboxByWriter(userId);
            return View(values);

        }
        [Route("Admin/[Controller]/[Action]")]
        [HttpGet]
        public IActionResult ComposeMessage()
        {
            var username = User.Identity.Name;
            var users = c.Users.ToList();
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userId = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            List<SelectListItem> selectUsers = (from x in users
                                                select new SelectListItem
                                                {
                                                    Text = x.UserName,
                                                    Value = x.Id.ToString()
                                                }).ToList();
            ViewBag.Receiver = selectUsers;
            return View();
        }
        [HttpPost]
        [Route("Admin/[Controller]/[Action]")]
        public IActionResult ComposeMessage(Message p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userId = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            p.SenderID = userId;
            p.Subject = p.MessageDetails;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.MessageStatus = true;
            nm.TAdd(p);
            return RedirectToAction("Sendbox");
        }
    }
}
