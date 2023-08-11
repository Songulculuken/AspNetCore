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
    }
}
