using Microsoft.AspNetCore.Mvc;

namespace Core.NETProject.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
