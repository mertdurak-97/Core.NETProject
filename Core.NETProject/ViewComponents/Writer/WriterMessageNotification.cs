using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core.NETProject.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager nm = new MessageManager(new EFMessageRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = nm.GetInboxByWriter(writerID);
            return View(values);
        }
    }
}
