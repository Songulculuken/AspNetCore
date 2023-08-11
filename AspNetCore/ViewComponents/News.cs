using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.ViewComponents
{
    public class News : ViewComponent //askenronik olarak çağırırız
    {
        public IViewComponentResult Invoke(string color = "default") //Invoke methodu ile ayağa kaldırırız. string color ="default" parametre gönderimi
        {
            var list = NewsContext.List;
            if (color == "default")
            {
                return View(list);
            }
            else if (color == "red")
            {
                return View("red", list);
            }
            else
                return View("blue", list);
        }
    }
}
