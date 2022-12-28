using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core.NETProject.ViewComponents.Writer
{
    public class UserAboutOnDashboard : ViewComponent
    {
        UserManager um = new UserManager(new EFUserRepository());

        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity?.Name;
            ViewBag.v = username;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userId = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = um.TGetByID(userId);
            return View(values);
        }
    }
}
