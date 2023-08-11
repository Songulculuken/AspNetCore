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
        public IActionResult Create()
        {
            if (TempData.ContainsKey("ErrorMessage"))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
                ViewBag.FolderName = TempData["FolderName"];
            }
            return View();  
        }
        [HttpPost]
        public IActionResult Create(string fileName)
        {
            FileInfo info = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", fileName));
            if (!info.Exists) 
            {
                info.Create();
                return RedirectToAction("List");   
            }
            else 
            {
                TempData["ErrorMessage"] = "Bu dosya zaten mevcut.";
                TempData["FolderName"] = fileName;
                return RedirectToAction("Create");
            }
        }
        public IActionResult Remove(string fileName) 
        {
            FileInfo info = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", fileName));
            if (info.Exists)
            {
                info.Delete();
            }
            return RedirectToAction("List");
        }
    }
}
