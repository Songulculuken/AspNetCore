using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        [Area("Member")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
