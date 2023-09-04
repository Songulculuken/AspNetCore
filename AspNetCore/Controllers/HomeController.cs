using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

            return View(new Customer());
        }
        [HttpPost]
        //MODEL Binding CreateWithForm(Customer customer)
        public IActionResult Create(Customer customer)
        {
            //Model Binding sayesinde alttaki 3 kod satırına ihtiyacımız olmuyor.
            //var firstName = HttpContext.Request.Form["firstName"].ToString();
            //var lastName = HttpContext.Request.Form["lastName"].ToString();
            //var age = int.Parse(HttpContext.Request.Form["Age"].ToString());
            // var control = ModelState.IsValid;
            //var errors = ModelState.Values.Select(ı => ı.Errors);//Property, Gelen sonuca göre Doğrulama 
            ModelState.Remove("Id");
            if(customer.FirstName == "Songül")
            {
                ModelState.AddModelError("", "Firstname songül olamaz");
            }
            if(ModelState.IsValid)
            {
                Customer lastCustomer = null;
                if (CustomerContext.Customers.Count > 0)
                {
                    lastCustomer = CustomerContext.Customers.Last();

                }
                customer.Id = 1;
                if (lastCustomer != null)
                {
                    customer.Id = lastCustomer.Id + 1;
                }
                //Model binding sayesinde buna da ihtiyacımız yok
                //int id = 1;
                //if (lastCustomer != null)
                //{
                //    id = lastCustomer.Id + 1;
                //}
                CustomerContext.Customers.Add(customer);
                //Model Binding sayesinde buna da ihtiyacımız yok.
                //CustomerContext.Customers.Add(new Customer
                //{
                //    Age = age,
                //    LastName = lastName,
                //    FirstName = firstName,
                //    Id = id
                //});
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            //Model Binding sayesinde gerek kalmıyor 
            //var id = int.Parse(RouteData.Values["id"].ToString()); //id yi bulup getirme 
            var removedCustomer = CustomerContext.Customers.Find(a => a.Id == id); //customerslar içinde her bir kayıt a. Predicate delege kullanma
            CustomerContext.Customers.Remove(removedCustomer);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            // Model Binding sayesinde gerek kalmıyor
            //var id = int.Parse(RouteData.Values["id"].ToString());
            var updatedCustomer = CustomerContext.Customers.FirstOrDefault(a => a.Id == id);
            return View(updatedCustomer);
        }
        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            //Model binding sayesinde gerek kalmıyor
            //var id = int.Parse(HttpContext.Request.Form["id"].ToString());
            var updatedCustomer = CustomerContext.Customers.FirstOrDefault(I => I.Id == customer.Id);
            //updatedCustomer.FirstName = HttpContext.Request.Form["firstName"].ToString();
            //updatedCustomer.LastName = HttpContext.Request.Form["lastName"].ToString();
            //updatedCustomer.Age = int.Parse(HttpContext.Request.Form["age"].ToString());
            updatedCustomer.FirstName = customer.FirstName; 
            updatedCustomer.LastName = customer.LastName;
            updatedCustomer.Age= customer.Age;  
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
