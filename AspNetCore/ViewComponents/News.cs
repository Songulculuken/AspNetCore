using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.ViewComponents
{
    public class News : ViewComponent //askenronik olarak çağırırız
    {
        public IViewComponentResult Invoke() //Invoke methodu ile ayağa kaldırırız.
        {
            var list = NewsContext.List;
            return View(list);  
        }
    }
}
