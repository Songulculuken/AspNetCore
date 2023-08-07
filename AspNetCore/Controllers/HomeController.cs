using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        //ysk.com.tr/Home/Index
        public IActionResult Index()
        {
            //viewbag,viewdata,tempdata,model
            ViewBag.Name = "Songül1";
            ViewData["Name"] = "Sinem1";
            TempData["Name"] = "Aslı1";

            Customer customer = new() { Age = 25, FirstName = "Songül", LastName = "Çuluken" };
            return View(customer);
        }
    }
}
