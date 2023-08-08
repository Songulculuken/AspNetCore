using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        //ysk.com.tr/Home/Index
        //RedirectToAction aslında bir IActionResulttır.View de IActionResulttır.
        //[Route("[controller]/[action]")] Attribute Routing ile yazılan şeyler startuptaki routing i ezer.
        //[Route("Songul")] Attribute Routing 
        [HttpGet]
        public IActionResult Index()
        {
            var customers = CustomerContext.Customers;
            return View(customers);
            //IText test = new Text();
            //IText test2 = new Text2();
            ////viewbag,viewdata,tempdata,model
            //ViewBag.Name = "Songül1";
            //ViewData["Name"] = "Sinem1";
            //TempData["Name"] = "Aslı1";
            ////Dictionary<string, object> dictionary = new();
            ////var list = dictionary.Values;
            ////var values = int.Parse(RouteData.Values["id"].ToString()); RoutData ile id çekme
            //Customer customer = new() { Age = 25, FirstName = "Songül", LastName = "Çuluken" };
            //return View(customer);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]  
        public IActionResult CreateWithForm()
        {
            var firstName= HttpContext.Request.Form["firstName"].ToString();   
            var lastName= HttpContext.Request.Form["lastName"].ToString();   
            var age= int.Parse(HttpContext.Request.Form["Age"].ToString());
            var lastCustomer = CustomerContext.Customers.Last();
            var id=lastCustomer.Id+1;
            CustomerContext.Customers.Add(new Customer
            {
                Age = age,
                LastName = lastName,
                FirstName = firstName,  
                Id = id
            });
            return RedirectToAction("Index");  
        }
        //public interface IText
        //{

        //}
        //public class Text : IText
        //{

        //}
        //public class Text2 : IText 
        //{ 

        //}

    }
}
