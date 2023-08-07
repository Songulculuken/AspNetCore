using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        //ysk.com.tr/Home/Index
        public IActionResult Index()
        {
            //viewbag,viwdata,tempdata,model
            ViewBag.Name = "Songül1";
            return View();
        }
    }
}
