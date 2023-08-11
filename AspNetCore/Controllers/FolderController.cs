using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace AspNetCore.Controllers
{
    public class FolderController: Controller
    {
        public IActionResult List() 
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")); //classtan yardım alarak klasördekileri listeleme
            var folders= directoryInfo.GetDirectories();
            return View(folders);
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
        public IActionResult Create(string folderName)
        {
            DirectoryInfo info = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",folderName));
            if(!info.Exists)
            {
                info.Create();
                return RedirectToAction("List");
            }
            else
            {
                TempData["ErrorMessage"] = "Bu klasör zaten mevcut.";
                TempData["FolderName"] = folderName;
                return RedirectToAction("Create");
            }
        }
        public IActionResult Remove(string folderName)
        {
            DirectoryInfo info = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName));
            if(info.Exists) 
            {
                info.Delete(true);
            }
            return RedirectToAction("List");
        }
    }
}
