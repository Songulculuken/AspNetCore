using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        //ysk.com.tr/Home/Index
        //RedirectToAction aslında bir IActionResulttır.View de IActionResulttır.
        [Route("[controller]/[action]")]
        public IActionResult Index()
        {
            IText test = new Text();
            IText test2 = new Text2();
            //viewbag,viewdata,tempdata,model
            ViewBag.Name = "Songül1";
            ViewData["Name"] = "Sinem1";
            TempData["Name"] = "Aslı1";
            //Dictionary<string, object> dictionary = new();
            //var list = dictionary.Values;
            //var values = int.Parse(RouteData.Values["id"].ToString()); RoutData ile id çekme
            Customer customer = new() { Age = 25, FirstName = "Songül", LastName = "Çuluken" };
            return View(customer);
        }
        public interface IText
        {

        }
        public class Text : IText
        {

        }
        public class Text2 : IText 
        { 

        }

    }
}
