using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetCore.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult Index ()
        {
            SetCookie();
            ViewBag.Cookie = GetCookie();
            return View();
        }
        private void SetCookie()
        {
            // dcoument.cookie
            HttpContext.Response.Cookies.Append("Course", "Asp Net Core", new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddDays(10),//bu kullanıcının ilgili clientın ne kadar süre tarayıcıda tutulacak
                HttpOnly = true, //ilgili kişi document.cookie yazdığı zaman yani js ile çekmeye çalıştığı zaman httponly true yapıp setlersek js ile ilgili cookiemiz kapanır ulaşamaz.
                SameSite=Microsoft.AspNetCore.Http.SameSiteMode.Strict //lax dışarıdaki sayfalarda kullanabilir. strict dersek sadece bu web sitesi kullanabilir.
            });
        }
        private string GetCookie()
        {
            string cookieValue=string.Empty;
            HttpContext.Request.Cookies.TryGetValue("Course", out cookieValue);
             return cookieValue;
        }
        //Response cookie setleme
        //Request cookie getirme
    }
}
