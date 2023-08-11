using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace AspNetCore.Controllers
{
    public class FileController : Controller
    {
        //Klasör altındaki dosyaları listeleme
        public IActionResult List()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files"));
            var files = directoryInfo.GetFiles();
            return View(files);
        }
    }
}
