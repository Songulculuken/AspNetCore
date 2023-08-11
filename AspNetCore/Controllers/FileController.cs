using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public IActionResult CreateWithData()
        {
            FileInfo info = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", Guid.NewGuid().ToString() + ".txt")); //benzersiz bir isim oluşturma dosya ismi
            StreamWriter writer = info.CreateText();
            writer.Write("Merhaba ben Songül"); //txt dosyasının içine yazılıyor.
            writer.Close();
            return RedirectToAction("List");
        }
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Upload(IFormFile formFile)
        {
            //1.jpg 1.jpg farklı resim ama aynı isimlere sahip 2. resim yüklenmesin
            // Guid.NewGuid(); //benzersiz isimler üretsin
            if (formFile.ContentType.StartsWith("image/") && (formFile.ContentType.EndsWith("png") ||formFile.ContentType.EndsWith("jpg") || formFile.ContentType.EndsWith("jpeg"))) //dosya kontrolü
            {
                var ext = Path.GetExtension(formFile.FileName); // uzantıyı bul ver
                var path = Directory.GetCurrentDirectory() + "/wwwroot" + "/images/" + Guid.NewGuid() + ext; ; //dosyayı kaydedeceği yer
                FileStream stream = new FileStream(path, FileMode.Create); //stream olarak alamayız abstract çünkü, kalıtsal yollarla filestream üzerinden alırız
                formFile.CopyTo(stream); //copyto upload işlemi
                TempData["message"] = "Dosya upload başarı ile gerçekleşti";
            }
            else
            {
                TempData["message"] = "Dosya upload edilemedi,uygunsuz dosya tipi";
            }
            return RedirectToAction("Upload");
        }
    }
}
